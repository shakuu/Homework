using SocialNetwork.ConsoleClient.Searcher;
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
            var service = new SocialNetworkService();
            DataSearcher.Search(service);
        }
    }
}
