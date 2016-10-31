using SocialNetwork.ConsoleClient.Searcher;
using SocialNetwork.ConsoleClient.XmlParsers;

namespace SocialNetwork.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            // Uncomment to insert data.
            //XmlParser.ParseFriendShipsXml(null);
            //XmlParser.ParsePostsXml(null);

            var service = new SocialNetworkService();
            DataSearcher.Search(service);
        }
    }
}
