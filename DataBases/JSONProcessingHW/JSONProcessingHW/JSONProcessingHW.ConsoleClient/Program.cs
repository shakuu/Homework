using JSONProcessingHW.Logic.ConfigurationReaders;

namespace JSONProcessingHW.ConsoleClient
{
    public class Program
    {
        private const string RssFeedUrlKey = "RSSFeedUrl";
        private const string TargetXmlFileLocation = "XmlFileLocation";

        static void Main()
        {
            var configReader = new AppConfigConfigurationReader();
            System.Console.WriteLine(configReader.ReaderConfiguration("RSSFeedUrl"));
        }
    }
}
