using System.Xml;

namespace XMLProcessingHW.ReadingXML.XMLReaders.Contracts
{
    interface IXmlDocumentRootProvider
    {
        XmlElement GetXmlDocumentRoot(string fileName);
    }
}
