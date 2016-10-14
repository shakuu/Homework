using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XMLProcessingHW.ReadingXML.XMLReaders.Contracts
{
    public interface IXmlDocumentProvider
    {
        XDocument GetXDocument(string fileName);

        XmlReader GetXmlReader(string fileName);

        XmlTextWriter GetXmlWriter(string fileName, Encoding encoding);

        XmlDocument GetXmlDocument(string fileName);

        void SetXmlDocument(string fileName, XmlDocument document);
    }
}
