using System;
using System.Collections;
using System.Xml;

using XMLProcessingHW.ReadingXML.XMLReaders.Contracts;

namespace XMLProcessingHW.ReadingXML.XMLReaders
{
    public class XmlDocumentParser : IXmlDocumentParser
    {
        private XmlElement rootElement;

        public XmlDocumentParser(XmlElement rootElement)
        {
            if (rootElement == null)
            {
                throw new ArgumentNullException(nameof(rootElement));
            }

            this.rootElement = rootElement;
        }

        public IDictionary ExtractValues(string keyElementName, string valueElementName)
        {
            throw new NotImplementedException();
        }
    }
}
