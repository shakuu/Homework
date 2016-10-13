using System.Xml;

using XMLProcessingHW.ReadingXML.XMLReaders.Contracts;

namespace XMLProcessingHW.ReadingXML.XMLReaders
{
    public class XmlDocumentRootProvider : IXmlDocumentRootProvider
    {
        public XmlElement GetXmlDocumentRoot(string fileName)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            var rootElement = xmlDocument.DocumentElement;
            return rootElement;
        }
    }
}
