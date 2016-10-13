using System;
using System.Collections;

using XMLProcessingHW.ReadingXML.XMLReaders;

namespace XMLProcessingHW.ReadingXML
{
    public class Startup
    {
        public static void Main()
        {
            var url = "D:\\GitHub\\Homework\\DataBases\\XMLProcessingHW\\XMLProcessingHW\\catalogue.xml";
            var rootElementProvider = new XmlDocumentRootProvider();
            var documentParser = new XmlDocumentParser(rootElementProvider);

            var resultWithDom = documentParser.ExtractValues(url, "album", "artist", "name");
            foreach (DictionaryEntry item in resultWithDom)
            {
                var authorName = item.Key;
                var songsList = (ICollection)item.Value;
                var songsCount = songsList.Count;

                Console.WriteLine($"{authorName} --- {songsCount}");
            }

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
    }
}
