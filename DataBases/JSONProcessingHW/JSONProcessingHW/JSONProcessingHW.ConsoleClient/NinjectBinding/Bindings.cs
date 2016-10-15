using Ninject.Modules;

using JSONProcessingHW.Logic.HtmlGenerator.Contracts;
using JSONProcessingHW.Logic.HtmlGenerator;
using JSONProcessingHW.Logic.Parsers.Contracts;
using JSONProcessingHW.Logic.Parsers;
using JSONProcessingHW.Logic.Models;
using JSONProcessingHW.Logic.DataServices.Contracts;
using JSONProcessingHW.Logic.DataServices;
using JSONProcessingHW.Logic.ConfigurationReaders;
using JSONProcessingHW.Logic.ConfigurationReaders.Contracts;
using JSONProcessingHW.Logic;

namespace JSONProcessingHW.ConsoleClient.NinjectBinding
{
    internal class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IHtmlFileCreator>().To<HtmlFileCreator>();
            this.Bind<IHtmlGenerator>().To<HtmlGenerator>();
            this.Bind<IJsonParser<YouTubeVideo>>().To<JsonParser<YouTubeVideo>>();
            this.Bind<IXmlToJsonConverter>().To<XmlToJsonConverter>();
            this.Bind<IXmlDocumentProvider>().To<XmlDocumentProvider>();
            this.Bind<IDataService>().To<WebClientDataService>();
            this.Bind<IConfigurationReader>().To<AppConfigConfigurationReader>();
            this.Bind<IDataParser>().To<DataParser>();
        }
    }
}
