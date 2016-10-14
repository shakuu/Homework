using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

using XMLProcessingHW.ReadingXML.XMLReaders.Contracts;

namespace XMLProcessingHW.ReadingXML.XMLReaders
{
    public class XmlDocumentProvider : IXmlDocumentProvider
    {
        public XDocument GetXDocument(string fileName)
        {
            var xDocument = XDocument.Load(fileName);
            return xDocument;
        }

        public XmlReader GetXmlReader(string fileName)
        {
            var reader = XmlReader.Create(fileName);
            return reader;
        }

        public XmlTextWriter GetXmlWriter(string fileName, Encoding encoding)
        {
            var writer = new XmlTextWriter(fileName, encoding);
            return writer;
        }

        public XmlDocument GetXmlDocument(string fileName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            return xmlDocument;
        }

        public void SetXmlDocument(string fileName, XmlDocument document)
        {
            document.Save(fileName);
        }
    }
}
