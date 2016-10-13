using System;
using System.Collections;
using System.Xml;

namespace XMLProcessingHW.ReadingXML.XMLReaders.Contracts
{
    public interface IXmlDocumentParser
    {
        void DeleteElementsWith(string fileName, string modifiedFileName, string containerElementName, Func<XmlElement, bool> matchForDeletion);

        IDictionary ExtractValuesWithXPath(string fileName, string rootElementName, string containerElementName, string keyElementName, string valueElementName);

        IDictionary ExtractValues(string fileName, string containerElementName, string keyElementName, string valueElementName);
    }
}
