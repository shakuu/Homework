using System.Xml;

using SocialNetwork.ConsoleClient.XmlReaderExtensionMethods;
using SocialNetwork.Data;

namespace SocialNetwork.ConsoleClient.XmlParsers
{
    public class XmlParserWithExtensionMethod
    {
        public static void ParsePostsToXml(string fileLocation)
        {
            if (string.IsNullOrEmpty(fileLocation))
            {
                fileLocation = "./XmlFiles/Posts.xml";
            }

            using (XmlReader xmlReader = XmlReader.Create(fileLocation))
            {
                var socialNetworkContext = XmlParserWithExtensionMethod.GetContext();
                var postCount = 0;

                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "Post")
                    {
                        postCount++;
                        var post = xmlReader.CreatePost(socialNetworkContext);

                        if (postCount % 50 == 0)
                        {
                            // Send to DB
                            // Get new context
                        }
                    }
                }
            }
        }

        public static void ParseFriendshipsToXml(string fileLocation)
        {
            if (string.IsNullOrEmpty(fileLocation))
            {
                fileLocation = "./XmlFiles/Friendships.xml";
            }

            using (XmlReader xmlReader = XmlReader.Create(fileLocation))
            {
                var socialNetworkContext = XmlParserWithExtensionMethod.GetContext();
                var friendshipsCount = 0;

                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "Friendship")
                    {
                        friendshipsCount++;
                        var isApprovedValue = xmlReader.GetAttribute("Approved");

                        var friendship = xmlReader.CreateFriendship(socialNetworkContext);
                        friendship.Approved = isApprovedValue == "true";

                        if (friendshipsCount % 50 == 0)
                        {
                            // Send to DB
                            // Get new context
                        }
                    }
                }
            }
        }

        private static SocialNetworkContext GetContext()
        {
            var context = new SocialNetworkContext();
            return context;
        }
    }
}
