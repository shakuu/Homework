using System.Xml;

using XMLProcessingHW.ReadingXML.XMLReaders.Contracts;

namespace XMLProcessingHW.ReadingXML.XMLReaders
{
    public class XmlDocumentRootProvider : IXmlDocumentProvider
    {
        public XmlDocument GetXmlDocument(string fileName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            return xmlDocument;
        }
    }
}
