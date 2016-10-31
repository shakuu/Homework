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
            //XmlParserWithExtensionMethod.ParsePostsToXml(null);
            //XmlParserWithExtensionMethod.ParseFriendshipsToXml(null);

            // Uncomment to insert data.
            //XmlParser.ParseFriendShipsXml(null);
            //XmlParser.ParsePostsXml(null);

            // Uncomment to create JSON files.
            //var service = new SocialNetworkService();
            //DataSearcher.Search(service);

            //XmlDeserializers.XmlDeserializer.DeserializeTo();

            var converter = new XmlToSqlModelConverter(ContextProvider.CreateSocialNetworkContext);
            var deserializer = new BasicXmlDeserializer();

            var xmlFriendships = deserializer.DeserializeTo<XmlFriendship>("./XmlFiles/Friendships-Test.xml", "Friendships");
            converter.ConvertXmlFriendshipToSqlFriendship(xmlFriendships);
        }
    }
}
