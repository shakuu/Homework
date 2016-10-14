using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

using XMLProcessingHW.ReadingXML.XMLReaders.Contracts;

namespace XMLProcessingHW.ReadingXML.XMLReaders
{
    public class XmlDocumentParser : IXmlDocumentParser
    {
        private IXmlDocumentProvider xmlDocumentProvider;

        public XmlDocumentParser(IXmlDocumentProvider xmlDocumentProvider)
        {
            if (xmlDocumentProvider == null)
            {
                throw new ArgumentNullException(nameof(xmlDocumentProvider));
            }

            this.xmlDocumentProvider = xmlDocumentProvider;
        }

        public IEnumerable<string> GetAllElementsWithNameUsingLinqToXml(
            string fileName,
            string searchedElementName)
        {
            var xDocument = this.xmlDocumentProvider.GetXDocument(fileName);
            var descendants = xDocument.Descendants();
            var result = descendants
                .Where(descendant => descendant.Name.LocalName == searchedElementName)
                .Select(descendant => descendant.Value);

            return result;
        }

        public IEnumerable<string> GetAllElementsWithNameUsingXmlReader(
            string fileName,
            string searchedElementName)
        {
            var result = new LinkedList<string>();
            var reader = this.xmlDocumentProvider.GetXmlReader(fileName);
            using (reader)
            {
                while (reader.Read())
                {
                    var isXmlElement = reader.NodeType == XmlNodeType.Element;
                    if (isXmlElement)
                    {
                        var currentElementName = reader.Name;
                        if (currentElementName == searchedElementName)
                        {
                            var content = reader.ReadElementContentAsString();
                            result.AddLast(content);
                        }
                    }
                }

                reader.Close();
            }

            return result;
        }

        public void DeleteElementsWith(
            string fileName,
            string modifiedFileName,
            string containerElementName,
            Func<XmlElement, bool> matchForDeletion)
        {
            var xmlDocument = this.xmlDocumentProvider.GetXmlDocument(fileName);
            var containingElements = xmlDocument.GetElementsByTagName(containerElementName);
            for (var index = 0; index < containingElements.Count; index++)
            {
                var element = containingElements[index] as XmlElement;

                var toBeDeleted = matchForDeletion(element);
                if (toBeDeleted)
                {
                    element.ParentNode.RemoveChild(element);
                    index--;
                }
            }

            this.xmlDocumentProvider.SetXmlDocument(modifiedFileName, xmlDocument);
        }

        public IDictionary ExtractValuesWithXPath(
            string fileName,
            string rootElementName,
            string containerElementName,
            string keyElementName,
            string valueElementName)
        {
            var xPathQuery = $"/{rootElementName}/{containerElementName}";

            var xmlDocument = this.xmlDocumentProvider.GetXmlDocument(fileName);
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
            var xmlDocument = this.xmlDocumentProvider.GetXmlDocument(fileName);
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
