using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

using XMLProcessingHW.ReadingXML.XMLReaders.Contracts;

namespace XMLProcessingHW.ReadingXML.XMLReaders
{
    public class XmlDocumentParser : IXmlDocumentParser
    {
        private IXmlDocumentProvider rootElementProvider;

        public XmlDocumentParser(IXmlDocumentProvider rootElementProvider)
        {
            if (rootElementProvider == null)
            {
                throw new ArgumentNullException(nameof(rootElementProvider));
            }

            this.rootElementProvider = rootElementProvider;
        }

        public IDictionary ExtractValuesWithXPath(
            string fileName,
            string rootElementName,
            string containerElementName,
            string keyElementName,
            string valueElementName)
        {
            var xPathQuery = $"/{rootElementName}/{containerElementName}";

            var xmlDocument = this.rootElementProvider.GetXmlDocument(fileName);
            var containingElements = xmlDocument.SelectNodes(xPathQuery);
            var result = this.ExtractDictionaryOfElements(containingElements, keyElementName, valueElementName);

            return result;
        }

        public IDictionary ExtractValues(
            string fileName,
            string containerElementName,
            string keyElementName,
            string valueElementName)
        {
            var xmlDocument = this.rootElementProvider.GetXmlDocument(fileName);
            var containingElements = xmlDocument.GetElementsByTagName(containerElementName);
            var result = this.ExtractDictionaryOfElements(containingElements, keyElementName, valueElementName);

            return result;
        }

        private IDictionary ExtractDictionaryOfElements(XmlNodeList elements, string keyElementName, string valueElementName)
        {
            var result = new Hashtable();
            foreach (XmlElement element in elements)
            {
                var key = this.ExtractInnerTextFromElement(element, keyElementName);
                var value = this.ExtractInnerTextFromElement(element, valueElementName);

                var keyIsNull = key == null;
                var valueIsNull = value == null;
                if (!(keyIsNull && valueIsNull))
                {
                    this.AddNewEntry(result, key, value);
                }
            }

            return result;
        }

        private void AddNewEntry(IDictionary container, string key, string value)
        {
            var containsKey = container.Contains(key);
            if (containsKey)
            {
                var currentListOfValues = (ICollection<string>)container[key];
                currentListOfValues.Add(value);
            }
            else
            {
                var listOfValues = new LinkedList<string>();
                listOfValues.AddLast(value);

                container.Add(key, listOfValues);
            }
        }

        private string ExtractInnerTextFromElement(XmlElement parent, string child)
        {
            string result = null;
            var childElement = parent[child];
            if (childElement != null)
            {
                result = childElement.InnerText;
            }

            return result;
        }
    }
}
