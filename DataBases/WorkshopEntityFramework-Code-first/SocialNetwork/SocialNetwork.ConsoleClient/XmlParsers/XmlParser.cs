using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.ConsoleClient.XmlParsers
{
    public static class XmlParser
    {
        public static void ParseFriendShipsXml(string fileLocation)
        {
            if (string.IsNullOrEmpty(fileLocation))
            {
                fileLocation = "./XmlFiles/Friendships.xml";
            }

            using (XmlReader xmlReader = XmlReader.Create(fileLocation))
            {
                var friendshipCount = 0;
                var socialNetworkContext = XmlParser.GetContext();

                var xmlBuilder = new StringBuilder();

                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "Friendship")
                    {
                        xmlBuilder.AppendLine(xmlReader.ReadOuterXml());
                        Console.WriteLine(xmlBuilder);
                        Console.WriteLine("--------------------------------------------------------------------");

                        var xmlExists = xmlBuilder.Length > 0;
                        if (xmlExists)
                        {
                            friendshipCount++;

                            var friendship = XmlParser.CreateFriendship(xmlBuilder.ToString(), socialNetworkContext);
                            socialNetworkContext.Friendships.Add(friendship);
                            xmlBuilder.Clear();

                            if (friendshipCount % 20 == 0)
                            {
                                socialNetworkContext.SaveChanges();
                                socialNetworkContext = XmlParser.GetContext();
                            }
                        }
                    }
                }

                socialNetworkContext.SaveChanges();
            }
        }

        public static void ParsePostsXml(string fileLocation)
        {
            if (string.IsNullOrEmpty(fileLocation))
            {
                fileLocation = "./XmlFiles/Posts.xml";
            }

            using (XmlReader xmlReader = XmlReader.Create(fileLocation))
            {
                var postsCount = 0;
                var socialNetworkContext = XmlParser.GetContext();

                var xmlBuilder = new StringBuilder();

                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "Post")
                    {
                        //var user = xmlReader.ReadNextUser();
                        xmlBuilder.AppendLine(xmlReader.ReadOuterXml());
                        Console.WriteLine(xmlBuilder);
                        Console.WriteLine("--------------------------------------------------------------------");

                        var xmlExists = xmlBuilder.Length > 0;
                        if (xmlExists)
                        {
                            postsCount++;
                            
                            var post = XmlParser.CreatePost(xmlBuilder.ToString(), socialNetworkContext);
                            socialNetworkContext.Posts.Add(post);
                            xmlBuilder.Clear();

                            if (postsCount % 50 == 0)
                            {
                                socialNetworkContext.SaveChanges();
                                socialNetworkContext = XmlParser.GetContext();
                            }
                        }
                    }
                }

                socialNetworkContext.SaveChanges();
            }
        }

        private static Post CreatePost(string xml, SocialNetworkContext context)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var root = doc.DocumentElement;

            var post = new Post();

            var content = root["Content"].InnerText;
            post.Content = content;

            try
            {
                var postedOn = DateTime.Parse(root["PostedOn"].InnerText);
                post.PostedOn = postedOn;
            }
            catch (Exception)
            {
                post.PostedOn = DateTime.Now;
            }

            var usernames = root["Users"].InnerText;
            var splitUsernames = usernames.Split(',').Select(u => u.Trim());
            var users = context.Users
                .Where(u => splitUsernames.Contains(u.Username))
                .ToList();

            post.TaggedUsers = users;

            return post;
        }

        private static Friendship CreateFriendship(string xml, SocialNetworkContext context)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var root = doc.DocumentElement;
            var friendship = new Friendship();

            var isApprovedValue = root.GetAttribute("Approved");
            var isApproved = isApprovedValue == "true";
            friendship.Approved = isApproved;

            try
            {
                var friendsSinceValue = root.GetElementsByTagName("FriendsSince")[0].InnerText;
                var friendsSince = DateTime.Parse(friendsSinceValue);

                friendship.FriendsSince = friendsSince;
            }
            catch (Exception)
            {
                friendship.FriendsSince = DateTime.Now;
            }

            var firstUserXml = root.GetElementsByTagName("FirstUser")[0];
            var firstUser = XmlParser.CreateUser(firstUserXml, context);
            friendship.UserA = firstUser;

            var secondUserXml = root.GetElementsByTagName("SecondUser")[0];
            var secondUser = XmlParser.CreateUser(secondUserXml, context);
            friendship.UserB = secondUser;

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

            var localUser = context.Users.Local
                .Where(u => u.Username == username)
                .FirstOrDefault();

            if (localUser != null)
            {
                return localUser;
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

        private static SocialNetworkContext GetTestConext()
        {
            var context = new SocialNetworkContext("testdb");
            return context;
        }
    }
}
