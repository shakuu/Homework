using System.IO;

using JSONProcessingHW.Logic.ConfigurationReaders;
using JSONProcessingHW.Logic.DataServices;
using JSONProcessingHW.Logic.HtmlGenerator;
using JSONProcessingHW.Logic.Models;
using JSONProcessingHW.Logic.Parsers;

namespace JSONProcessingHW.ConsoleClient
{
    public class Program
    {
        private const string RssFeedUrlKey = "RSSFeedUrl";
        private const string TargetXmlFileLocationKey = "XmlFileLocation";
        private const string OutputHtmlFileLocationKey = "HtmlFileLocation";

        static void Main()
        {
            var configReader = new AppConfigConfigurationReader();
            var rssFeedUrl = configReader.ReadConfiguration(Program.RssFeedUrlKey);
            var fileLocation = configReader.ReadConfiguration(Program.TargetXmlFileLocationKey);

            var dataService = new WebClientDataService();
            dataService.GetData(rssFeedUrl, fileLocation);

            var documentProvider = new XmlDocumentProvider();
            var xmlDocument = documentProvider.GetXmlDocument(fileLocation);

            var xmlToJsonConverter = new XmlToJsonConverter();
            var json = xmlToJsonConverter.ConvertXmlToJson(xmlDocument);

            var parser = new JsonParser<YouTubeVideo>();
            var data = parser.ParseJson(json, "feed", "entry");

            var htmlGenerator = new HtmlGenerator();
            var html = htmlGenerator.GenerateHtml(data);

            var outputFile = configReader.ReadConfiguration(Program.OutputHtmlFileLocationKey);
            File.WriteAllText(outputFile, html);
        }
    }
}
