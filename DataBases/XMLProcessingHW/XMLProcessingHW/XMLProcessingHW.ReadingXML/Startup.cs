using System.Xml;
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

            var result = documentParser.ExtractValues(url, "album", "artist", "name");
            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
