using System;
using System.Xml;
using System.Xml.Schema;

using JSONProcessingHW.Logic.Parsers.Contracts;

namespace JSONProcessingHW.Logic.Parsers
{
    public class XmlDocumentProvider : IXmlDocumentProvider
    {
        public XmlDocument GetXmlDocument(string fileName, string validationSchema = null)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var validationSchemaIsProvided = validationSchema != null;
            if (validationSchemaIsProvided)
            {
                var xmlReaderSettings = new XmlReaderSettings();
                xmlReaderSettings.Schemas.Add("http://www.myxml.com/myschema", validationSchema);
                xmlReaderSettings.ValidationType = ValidationType.Schema;

                var xmlReader = XmlReader.Create(fileName, xmlReaderSettings);
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlReader);

                var failedValidationEventHandler = new ValidationEventHandler(OnFailedValidation);
                xmlDocument.Validate(failedValidationEventHandler);

                return xmlDocument;
            }
            else
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                return xmlDocument;
            }
        }

        private void OnFailedValidation(object sender, ValidationEventArgs e)
        {
            throw new ArgumentException("Invalid XML format.");
        }
    }
}
