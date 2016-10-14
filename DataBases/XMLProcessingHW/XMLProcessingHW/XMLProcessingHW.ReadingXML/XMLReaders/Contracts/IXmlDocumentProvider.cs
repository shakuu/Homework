using System.Xml;

namespace XMLProcessingHW.ReadingXML.XMLReaders.Contracts
{
    public interface IXmlDocumentProvider
    {
        XmlReader GetXmlReader(string fileName);

        XmlDocument GetXmlDocument(string fileName);

        void SetXmlDocument(string fileName, XmlDocument document);
    }
}
