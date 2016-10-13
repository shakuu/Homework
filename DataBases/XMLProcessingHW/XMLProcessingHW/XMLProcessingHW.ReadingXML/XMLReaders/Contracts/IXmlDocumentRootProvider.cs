using System.Xml;

namespace XMLProcessingHW.ReadingXML.XMLReaders.Contracts
{
    public interface IXmlDocumentRootProvider
    {
        XmlElement GetXmlDocumentRoot(string fileName);
    }
}
