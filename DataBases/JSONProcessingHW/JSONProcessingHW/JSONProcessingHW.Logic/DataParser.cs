using System;
using System.Collections.Generic;

using JSONProcessingHW.Logic.ConfigurationReaders.Contracts;
using JSONProcessingHW.Logic.HtmlGenerator.Contracts;
using JSONProcessingHW.Logic.Models.Contracts;
using JSONProcessingHW.Logic.Parsers.Contracts;

namespace JSONProcessingHW.Logic
{
    public class DataParser : IDataParser
    {
        private const string RootElementName = "feed";
        private const string ContentElementName = "entry";
        private const string HtmlDocumentTitle = "YouTube RSS";
        private const string ValidationSchemaConfigKey = "DataParserSchemaFileName";

        private readonly IXmlDocumentProvider xmlDocumentProvider;
        private readonly IXmlToJsonConverter xmlToJsonConverter;
        private readonly IJsonParser jsonParser;
        private readonly IHtmlGenerator htmlGenerator;
        private readonly IHtmlFileCreator htmlCreator;
        private readonly IJTokenValueExtractor titleCallback;
        private readonly IJTokenValueExtractor urlCallback;
        private readonly string validationSchemaFileName;

        public DataParser(
            IXmlDocumentProvider xmlDocumentProvider,
            IXmlToJsonConverter xmlToJsonConverter,
            IJsonParser jsonParser,
            IHtmlGenerator htmlGenerator,
            IHtmlFileCreator htmlCreator,
            IJTokenValueExtractorProvider valueExtractorProvider,
            IConfigurationReader configurationReader)
        {
            if (xmlDocumentProvider == null)
            {
                throw new ArgumentNullException(nameof(xmlDocumentProvider));
            }

            if (xmlToJsonConverter == null)
            {
                throw new ArgumentNullException(nameof(xmlToJsonConverter));
            }

            if (jsonParser == null)
            {
                throw new ArgumentNullException(nameof(jsonParser));
            }

            if (htmlGenerator == null)
            {
                throw new ArgumentNullException(nameof(htmlGenerator));
            }

            if (htmlCreator == null)
            {
                throw new ArgumentNullException(nameof(htmlCreator));
            }

            if (valueExtractorProvider == null)
            {
                throw new ArgumentNullException(nameof(valueExtractorProvider));
            }

            if (configurationReader == null)
            {
                throw new ArgumentNullException(nameof(configurationReader));
            }

            this.xmlDocumentProvider = xmlDocumentProvider;
            this.xmlToJsonConverter = xmlToJsonConverter;
            this.jsonParser = jsonParser;
            this.htmlGenerator = htmlGenerator;
            this.htmlCreator = htmlCreator;
            this.titleCallback = valueExtractorProvider.CreateJTokenValueExtractor(new[] { "title" });
            this.urlCallback = valueExtractorProvider.CreateJTokenValueExtractor(new[] { "link", "@href" });
            this.validationSchemaFileName = configurationReader.ReadConfiguration(DataParser.ValidationSchemaConfigKey);
        }

        public void CreateHtml<ModelType>(string inputXmlFile, string outputHtmlFile)
            where ModelType : IModel, new()
        {
            // XML cannot be validated due to inconsistent <entry> element content.
            // <entry> elements contain varying sets of child elements.
            var xmlDocument = this.xmlDocumentProvider.GetXmlDocument(inputXmlFile);
            var json = this.xmlToJsonConverter.ConvertXmlToJson(xmlDocument);
            var data = this.jsonParser.ParseJson<ModelType>(json, DataParser.RootElementName, DataParser.ContentElementName, this.titleCallback, this.urlCallback);
            var html = this.htmlGenerator.GenerateHtml((IEnumerable<IModel>)data);
            this.htmlCreator.CreateHtmlFile(outputHtmlFile, DataParser.HtmlDocumentTitle, html);
        }
    }
}
