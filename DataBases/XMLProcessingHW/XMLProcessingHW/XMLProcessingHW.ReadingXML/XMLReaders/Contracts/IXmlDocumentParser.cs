using System.Collections;

namespace XMLProcessingHW.ReadingXML.XMLReaders.Contracts
{
    public interface IXmlDocumentParser
    {
        IDictionary ExtractValues(string fileName, string containerElementName, string keyElementName, string valueElementName);
    }
}
