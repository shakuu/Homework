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
            var rootElementProvider = new XmlDocumentRootProvider();
            var documentParser = new XmlDocumentParser(rootElementProvider);

            ExecuteDisplayWithDomParser(url, documentParser);

            Console.WriteLine("----------------------------------");

            var resultWithXPath = documentParser.ExtractValuesWithXPath(url, "catalogue", "album", "artist", "name");
            foreach (DictionaryEntry item in resultWithXPath)
            {
                var authorName = item.Key;
                var songsList = (ICollection)item.Value;
                var songsCount = songsList.Count;

                Console.WriteLine($"{authorName} --- {songsCount}");
            }
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
    }
}
