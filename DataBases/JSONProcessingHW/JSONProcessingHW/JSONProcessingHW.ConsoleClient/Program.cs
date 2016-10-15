using System.Reflection;

using Ninject;

using JSONProcessingHW.Logic;
using JSONProcessingHW.Logic.ConfigurationReaders.Contracts;
using JSONProcessingHW.Logic.DataServices.Contracts;

namespace JSONProcessingHW.ConsoleClient
{
    public class Program
    {
        private const string RssFeedUrlKey = "RSSFeedUrl";
        private const string TargetXmlFileLocationKey = "XmlFileLocation";
        private const string OutputHtmlFileLocationKey = "HtmlFileLocation";

        static void Main()
        {
            var ninject = new StandardKernel();
            ninject.Load(Assembly.GetExecutingAssembly());

            var configReader = ninject.Get<IConfigurationReader>();
            var rssFeedUrl = configReader.ReadConfiguration(Program.RssFeedUrlKey);
            var xmlFileLocation = configReader.ReadConfiguration(Program.TargetXmlFileLocationKey);
            var htmlFileLocation = configReader.ReadConfiguration(Program.OutputHtmlFileLocationKey);

            var rssLoader = ninject.Get<IDataService>();
            rssLoader.GetData(rssFeedUrl, xmlFileLocation);

            var dataParser = ninject.Get<IDataParser>();
            dataParser.CreateHtml(xmlFileLocation, htmlFileLocation);
        }
    }
}
