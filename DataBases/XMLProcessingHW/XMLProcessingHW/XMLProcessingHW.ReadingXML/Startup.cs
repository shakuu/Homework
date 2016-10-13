using System;
using System.Collections;

using XMLProcessingHW.ReadingXML.XMLReaders;
using XMLProcessingHW.ReadingXML.XMLReaders.Contracts;

namespace XMLProcessingHW.ReadingXML
{
    public class Startup
    {
        public static void Main()
        {
            var url = "D:\\GitHub\\Homework\\DataBases\\XMLProcessingHW\\XMLProcessingHW\\catalogue.xml";
            var documentParser = CreateDocumentParser();

            ExecuteDisplayWithDomParser(url, documentParser);

            Console.WriteLine("----------------------------------");

            ExecuteDisplayWithXPath(url, documentParser);
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
            var rootElementProvider = new XmlDocumentRootProvider();
            var documentParser = new XmlDocumentParser(rootElementProvider);

            return documentParser;
        }
    }
}
