using System;
using System.Collections;
using System.Text;
using System.Xml;

using XMLProcessingHW.ReadingXML.DirectoryStructureGenerators;
using XMLProcessingHW.ReadingXML.XMLReaders;
using XMLProcessingHW.ReadingXML.XMLReaders.Contracts;

namespace XMLProcessingHW.ReadingXML
{
    public class Startup
    {
        public static void Main()
        {
            var url = "D:\\GitHub\\Homework\\DataBases\\XMLProcessingHW\\XMLProcessingHW\\catalogue.xml";
            var urlModifiedDocument = "D:\\GitHub\\Homework\\DataBases\\XMLProcessingHW\\XMLProcessingHW\\catalogue-modified.xml";

            var documentParser = CreateDocumentParser();

            ExecuteDisplayWithDomParser(url, documentParser);

            Console.WriteLine("----------------------------------");

            ExecuteDisplayWithXPath(url, documentParser);

            Console.WriteLine("----------------------------------");

            ExecuteDeleteElements(url, urlModifiedDocument, documentParser);

            Console.WriteLine("----------------------------------");

            ExecuteSearchForElementWithNameUsingXmlReader(url, documentParser);

            Console.WriteLine("----------------------------------");

            ExecuteSearchForElementsWithNameUsingLinqToXml(url, documentParser);

            Console.WriteLine("----------------------------------");

            WriteNewXmlWithDIfferentStructure(url, documentParser);

            Console.WriteLine("----------------------------------");

            FolderStructure();
        }

        private static void FolderStructure()
        {
            var encoding = Encoding.GetEncoding("windows-1251");
            var outputFileName = "D:\\GitHub\\Homework\\DataBases\\XMLProcessingHW\\XMLProcessingHW\\directories.xml";
            var logger = new XmlDirectoryStructureLogger(outputFileName, encoding);
            var generator = new DirectoryStructureGenerator();

            generator.GenerateDirectoryStructure("D:\\test", logger);
        }

        private static void ExecuteSearchForElementsWithNameUsingLinqToXml(string url, IXmlDocumentParser documentParser)
        {
            var songTitles = documentParser.GetAllElementsWithNameUsingLinqToXml(url, "title");
            foreach (var title in songTitles)
            {
                Console.WriteLine($"Song Title: {title}");
            }
        }

        private static void ExecuteSearchForElementWithNameUsingXmlReader(string url, IXmlDocumentParser documentParser)
        {
            var songTitles = documentParser.GetAllElementsWithNameUsingXmlReader(url, "title");
            foreach (var title in songTitles)
            {
                Console.WriteLine($"Song Title: {title}");
            }
        }

        private static void ExecuteDeleteElements(string url, string urlModifiedDocument, IXmlDocumentParser documentParser)
        {
            Func<XmlElement, bool> predicate = (XmlElement element) =>
            {
                const int maximumPrice = 20;
                var result = false;

                int price;
                var priceIsParsed = int.TryParse(element["price"].InnerText, out price);
                if (priceIsParsed)
                {
                    var priceIsLargerThan = price > maximumPrice;
                    result = priceIsLargerThan;
                }

                return result;
            };

            documentParser.DeleteElementsWith(url, urlModifiedDocument, "album", predicate);
            ExecuteDisplayWithDomParser(urlModifiedDocument, documentParser);
        }

        private static void WriteNewXmlWithDIfferentStructure(string url, IXmlDocumentParser documentParser)
        {
            var encoding = Encoding.GetEncoding("windows-1251");
            var outputFileName = "D:\\GitHub\\Homework\\DataBases\\XMLProcessingHW\\XMLProcessingHW\\catalogue-reorganized.xml";
            documentParser.WriteToXmlDocumentUsingXmlTextWriter(url, outputFileName, encoding, "album", "artist", "name");
        }

        private static void ExecuteDisplayWithDomParser(string url, IXmlDocumentParser documentParser)
        {
            var resultWithDom = documentParser.ExtractValues(url, "album", "artist", "name");
            foreach (DictionaryEntry item in resultWithDom)
            {
                var authorName = item.Key;
                var songsList = (ICollection)item.Value;
                var songsCount = songsList.Count;

                Console.WriteLine($"{authorName} --- {songsCount}");
            }
        }

        private static void ExecuteDisplayWithXPath(string url, IXmlDocumentParser documentParser)
        {
            var resultWithXPath = documentParser.ExtractValuesWithXPath(url, "catalogue", "album", "artist", "name");
            foreach (DictionaryEntry item in resultWithXPath)
            {
                var authorName = item.Key;
                var songsList = (ICollection)item.Value;
                var songsCount = songsList.Count;

                Console.WriteLine($"{authorName} --- {songsCount}");
            }
        }

        private static IXmlDocumentParser CreateDocumentParser()
        {
            var rootElementProvider = new XmlDocumentProvider();
            var documentParser = new XmlDocumentParser(rootElementProvider);

            return documentParser;
        }
    }
}
