using System.Xml;

namespace JSONProcessingHW.Logic.Parsers.Contracts
{
    public interface IXmlDocumentProvider
    {
        XmlDocument GetXmlDocument(string fileName);
    }
}
