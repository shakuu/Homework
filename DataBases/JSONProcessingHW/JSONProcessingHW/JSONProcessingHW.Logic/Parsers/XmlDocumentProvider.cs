using System;
using System.Xml;

using JSONProcessingHW.Logic.Parsers.Contracts;

namespace JSONProcessingHW.Logic.Parsers
{
    public class XmlDocumentProvider : IXmlDocumentProvider
    {
        public XmlDocument GetXmlDocument(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            return xmlDocument;
        }
    }
}
