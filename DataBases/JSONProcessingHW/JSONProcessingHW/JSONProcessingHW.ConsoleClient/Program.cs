using JSONProcessingHW.Logic.ConfigurationReaders;
using JSONProcessingHW.Logic.DataServices;

namespace JSONProcessingHW.ConsoleClient
{
    public class Program
    {
        private const string RssFeedUrlKey = "RSSFeedUrl";
        private const string TargetXmlFileLocation = "XmlFileLocation";

        static void Main()
        {
            var configReader = new AppConfigConfigurationReader();
            var rssFeedUrl = configReader.ReadConfiguration(Program.RssFeedUrlKey);
            var fileLocation = configReader.ReadConfiguration(Program.TargetXmlFileLocation);

            var dataService = new WebClientDataService();
            dataService.GetData(rssFeedUrl, fileLocation);
        }
    }
}
