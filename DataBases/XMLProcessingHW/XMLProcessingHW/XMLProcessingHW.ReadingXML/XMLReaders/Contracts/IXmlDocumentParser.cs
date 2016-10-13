using System.Collections;

namespace XMLProcessingHW.ReadingXML.XMLReaders.Contracts
{
    public interface IXmlDocumentParser
    {
        IDictionary ExtractValuesWithXPath(string fileName, string rootElementName, string containerElementName, string keyElementName, string valueElementName);

        IDictionary ExtractValues(string fileName, string containerElementName, string keyElementName, string valueElementName);
    }
}
