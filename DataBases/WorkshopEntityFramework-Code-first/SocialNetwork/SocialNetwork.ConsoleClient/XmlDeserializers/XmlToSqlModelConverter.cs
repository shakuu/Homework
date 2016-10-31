using System;
using System.Collections.Generic;

using SocialNetwork.ConsoleClient.XmlDeserializers.Models;
using SocialNetwork.Data;
using SocialNetwork.Models;
using System.Linq;

namespace SocialNetwork.ConsoleClient.XmlDeserializers
{
    public class XmlToSqlModelConverter
    {
        private readonly Func<SocialNetworkContext> contextCreator;

        public XmlToSqlModelConverter(Func<SocialNetworkContext> contextCreator)
        {
            this.contextCreator = contextCreator;
        }

        public void ConvertXmlFriendshipToSqlFriendship(IEnumerable<XmlFriendship> xmlFriendships)
        {
            if (xmlFriendships == null)
            {
                throw new ArgumentNullException(nameof(xmlFriendships));
            }

            var context = this.contextCreator();

            var friendshipCount = 0;
            foreach (var friendship in xmlFriendships)
            {
                friendshipCount++;

                var newFriendship = new Friendship();
                newFriendship.Approved = friendship.Approved;
                newFriendship.FriendsSince = friendship.FriendsSince.HasValue ?
                    friendship.FriendsSince.Value : DateTime.Now;

                var firstUser = this.ConvertXmlUserToSqlUser(friendship.FirstUser, context);
                newFriendship.UserA = firstUser;

                var secondUser = this.ConvertXmlUserToSqlUser(friendship.SecondUser, context);
                newFriendship.UserB = secondUser;

                foreach (var message in friendship.Messages)
                {
                    var convertedMessages = this.ConvertXmlMessageToSqlMessage(message, firstUser, secondUser);
                    newFriendship.Messages.Add(convertedMessages);
                }

                //context.Friendships.Add(newFriendship);

                //if (friendshipCount % 50 == 0)
                //{
                //    context.SaveChanges();
                //    context = this.contextCreator();
                //}
            }

            //context.SaveChanges();
        }

        public User ConvertXmlUserToSqlUser(XmlUser user, SocialNetworkContext context)
        {
            var localUser = context.Users.Local
                .Where(u => u.Username == user.Username)
                .FirstOrDefault();

            if (localUser != null)
            {
                return localUser;
            }

            var dbUser = context.Users
                .Where(u => u.Username == user.Username)
                .FirstOrDefault();

            if (dbUser != null)
            {
                return dbUser;
            }

            var newUser = new User();
            newUser.Username = user.Username;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.RegisteredOn = user.RegisteredOn;

            foreach (var image in user.Images)
            {
                var convertedImage = this.ConvertXmlImageToSqlImage(image);
                newUser.Images.Add(convertedImage);
            }

            return newUser;
        }

        public Image ConvertXmlImageToSqlImage(XmlImage image)
        {
            var newImage = new Image();
            newImage.ImageUrl = image.ImageUrl;
            newImage.FileExtension = image.ImageUrl;

            return newImage;
        }

        public Message ConvertXmlMessageToSqlMessage(XmlMessage message, User first, User second)
        {
            var newMessage = new Message();
            newMessage.Author = first.Username == message.Author ? first : second;
            newMessage.Content = message.Content;
            newMessage.SentOn = message.SentOn;
            newMessage.SeenOn = message.SeenOn;

            return newMessage;
        }
    }
}
