using System.Collections;

namespace XMLProcessingHW.ReadingXML.XMLReaders.Contracts
{
    public interface IXmlDocumentParser
    {
        IDictionary ExtractValues(string keyElementName, string valueElementName);
    }
}
