using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using SocialNetwork.Data;
using SocialNetwork.Models;
using System.Linq;

namespace SocialNetwork.ConsoleClient.XmlParsers
{
    public static class XmlParser
    {
        public static void ParseFriendShipsXml(string fileLocation)
        {
            if (string.IsNullOrEmpty(fileLocation))
            {
                fileLocation = "./XmlFiles/Friendships-Test.xml";
            }

            using (XmlReader xmlReader = XmlReader.Create(fileLocation))
            {
                var friendshipCount = 0;
                var socialNetworkContext = XmlParser.GetContext();

                var xmlBuilder = new StringBuilder();
                var isFriendship = false;

                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "Friendship")
                    {
                        Console.WriteLine(xmlBuilder);
                        isFriendship = true;

                        var xmlExists = xmlBuilder.Length > 0;
                        if (xmlExists)
                        {
                            friendshipCount++;

                            // Parse XML
                            var friendship = XmlParser.CreateFriendship(xmlBuilder.ToString(), socialNetworkContext);
                            socialNetworkContext.Friendships.Add(friendship);

                            xmlBuilder.Clear();
                            isFriendship = false;

                            if (friendshipCount % 20 == 0)
                            {
                                socialNetworkContext.SaveChanges();
                                socialNetworkContext = XmlParser.GetContext();
                            }
                        }
                    }

                    if (isFriendship)
                    {
                        xmlBuilder.AppendLine(xmlReader.ReadOuterXml());
                    }
                }
            }
        }

        private static Friendship CreateFriendship(string xml, SocialNetworkContext context)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var root = doc.DocumentElement;
            var friendship = new Friendship();

            var isApprovedValue = root.GetAttribute("Approved");
            var isApproved = isApprovedValue == "true";

            var friendsSinceValue = root.GetElementsByTagName("FriendsSince")[0].InnerText;
            var friendsSince = DateTime.Parse(friendsSinceValue);

            friendship.Approved = isApproved;
            friendship.FriendsSince = friendsSince;

            var firstUserXml = root.GetElementsByTagName("FirstUser")[0];
            var firstUser = XmlParser.CreateUser(firstUserXml, context);
            friendship.UserA = firstUser;

            var secondUserXml = root.GetElementsByTagName("SecondUser")[0];
            var secondUser = XmlParser.CreateUser(secondUserXml, context);
            friendship.UserB = firstUser;

            /*<Message>
        <Author>ZtlKYHVN7h8SwMmaJs</Author>
        <Content>tNyppieXJadpvDTJEe7kTF6ia0h86gkooAn</Content>
        <SentOn>2011-04-19T15:02:36</SentOn>
        <SeenOn xsi:nil="true" />
      </Message>*/
            var messagesNodes = root.GetElementsByTagName("Message");
            foreach (XmlNode message in messagesNodes)
            {
                var authorName = message["Author"].InnerText;
                var content = message["Content"].InnerText;
                var sentOn = DateTime.Parse(message["SentOn"].InnerText);

                var author = firstUser.Username == authorName ? firstUser : secondUser;

                var newMessage = new Message()
                {
                    Author = author,
                    Content = content,
                    SentOn = sentOn
                };

                try
                {
                    newMessage.SeenOn = DateTime.Parse(message["SeenOn"].InnerText);
                }
                catch (Exception)
                {
                    newMessage.SeenOn = null;
                }

                friendship.Messages.Add(newMessage);
            }

            return friendship;
        }

        /*<FirstUser>
      <Username>x0spcgDKZBf3vQjfO</Username>
      <RegisteredOn>2012-08-03T08:13:24</RegisteredOn>
      <FirstName>fUNd3sToA59PJZaL0xCaZ8QthlOe9rAZW3Ku</FirstName>
      <LastName>HbnLHS0CKdmg</LastName>
      <Images>
        <Image>
          <ImageUrl>m1g3Fd99UO9ZCHfRo</ImageUrl>
          <FileExtension>FcPv</FileExtension>
        </Image>
        <Image>
          <ImageUrl>9mmb1VutUhta</ImageUrl>
          <FileExtension>2I</FileExtension>
        </Image>
      </Images>
    </FirstUser>*/
        private static User CreateUser(XmlNode xmlUser, SocialNetworkContext context)
        {
            var username = xmlUser["Username"].InnerText;

            var existingUser = context.Users
                .Where(u => u.Username == username)
                .FirstOrDefault();

            if (existingUser != null)
            {
                return existingUser;
            }

            var user = new User();
            user.Username = username;

            var regiesteredOn = DateTime.Parse(xmlUser["RegisteredOn"].InnerText);
            user.RegisteredOn = regiesteredOn;

            try
            {
                var firstNameExists = xmlUser["FirstName"].InnerText;
                user.FirstName = firstNameExists;
            }
            catch (Exception)
            {
            }

            try
            {
                var lastNameExists = xmlUser["LastName"].InnerText;
                user.LastName = lastNameExists;
            }
            catch (Exception)
            {
            }

            var imagesModels = new List<Image>();
            var imagesNodes = xmlUser["Images"].ChildNodes;
            foreach (XmlNode image in imagesNodes)
            {
                var url = image["ImageUrl"].InnerText;
                var ext = image["FileExtension"].InnerText;

                var newImage = new Image()
                {
                    ImageUrl = url,
                    FileExtension = ext
                };

                user.Images.Add(newImage);
            }

            return user;
        }

        private static SocialNetworkContext GetContext()
        {
            var context = new SocialNetworkContext();
            return context;
        }
    }
}
