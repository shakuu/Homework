using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SocialNetwork.ConsoleClient.XmlParsers
{
    public static class XmlParser
    {
        public static void ParseXml(string fileLocation)
        {
            if (string.IsNullOrEmpty(fileLocation))
            {
                fileLocation = "./XmlFiles/Friendships-Test.xml";
            }

            using (XmlReader xmlReader = XmlReader.Create(fileLocation))
            {
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
                            // Parse XML
                            var friendship = XmlParser.CreateFriendship(xmlBuilder.ToString());
                            xmlBuilder.Clear();
                            isFriendship = false;
                        }
                    }

                    if (isFriendship)
                    {
                        xmlBuilder.AppendLine(xmlReader.ReadOuterXml());
                    }
                }
            }
        }

        private static Friendship CreateFriendship(string xml)
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
            var firstUser = XmlParser.CreateUser(firstUserXml);
            friendship.UserA = firstUser;

            var secondUserXml = root.GetElementsByTagName("SecondUser")[0];
            var secondUser = XmlParser.CreateUser(secondUserXml);
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
        private static User CreateUser(XmlNode xmlUser)
        {
            var user = new User();

            var username = xmlUser["Username"].InnerText;
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
    }
}
