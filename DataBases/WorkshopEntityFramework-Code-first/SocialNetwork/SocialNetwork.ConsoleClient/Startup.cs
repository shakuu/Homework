using SocialNetwork.ConsoleClient.Searcher;
using SocialNetwork.ConsoleClient.XmlDeserializers;
using SocialNetwork.ConsoleClient.XmlDeserializers.Models;
using SocialNetwork.ConsoleClient.XmlParsers;

namespace SocialNetwork.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            // Run update-database in console

            // Insert data with extension methods
            //XmlParserWithExtensionMethod.ParsePostsToXml(null);
            //XmlParserWithExtensionMethod.ParseFriendshipsToXml(null);

            // Uncomment to insert data with XmlReader and XmlDocument
            //XmlParser.ParseFriendShipsXml(null);
            //XmlParser.ParsePostsXml(null);
                                   
            // Inser data with XmlSerializer
            var converter = new XmlToSqlModelConverter(ContextProvider.CreateSocialNetworkContext);
            var deserializer = new BasicXmlDeserializer();

            var xmlFriendships = deserializer.DeserializeTo<XmlFriendship>("./XmlFiles/Friendships.xml", "Friendships");
            converter.ConvertXmlFriendshipToSqlFriendship(xmlFriendships);

            var xmlPosts = deserializer.DeserializeTo<XmlPost>("./XmlFiles/Posts.xml", "Posts");
            converter.ConvertXmlPostToSqlPost(xmlPosts);

            // Uncomment to create JSON files.
            //var service = new SocialNetworkService();
            //DataSearcher.Search(service);
        }
    }
}
