using System.Reflection;

using Ninject;

using JSONProcessingHW.Logic.ConfigurationReaders;
using JSONProcessingHW.Logic;

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

            var configReader = new AppConfigConfigurationReader();
            var rssFeedUrl = configReader.ReadConfiguration(Program.RssFeedUrlKey);
            var fileLocation = configReader.ReadConfiguration(Program.TargetXmlFileLocationKey);
            var outputFile = configReader.ReadConfiguration(Program.OutputHtmlFileLocationKey);
            
            var dataParser = ninject.Get<IDataParser>();
        }
    }
}
