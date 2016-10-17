using System.Reflection;

using Ninject;

using JSONProcessingHW.Logic;
using JSONProcessingHW.Logic.ConfigurationReaders.Contracts;
using JSONProcessingHW.Logic.DataServices.Contracts;
using JSONProcessingHW.Logic.Models;
using JSONProcessingHW.Logic.Models.Contracts;

namespace JSONProcessingHW.ConsoleClient
{
    public class Program
    {
        private const string RssFeedUrlKey = "RSSFeedUrl";
        private const string TargetXmlFileLocationKey = "XmlFileLocation";
        private const string OutputHtmlFileLocationKey = "HtmlFileLocation";

        public static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var configReader = ninject.Get<IConfigurationReader>();
            string rssFeedUrl = configReader.ReadConfiguration(Program.RssFeedUrlKey);
            string xmlFileLocation = configReader.ReadConfiguration(Program.TargetXmlFileLocationKey);
            string htmlFileLocation = configReader.ReadConfiguration(Program.OutputHtmlFileLocationKey);

            var rssLoader = ninject.Get<IDataService>();
            rssLoader.GetData(rssFeedUrl, xmlFileLocation);

            var dataParser = ninject.Get<IDataParser>();
            dataParser.CreateHtml<YouTubeVideo>(xmlFileLocation, htmlFileLocation);
        }
    }
}
