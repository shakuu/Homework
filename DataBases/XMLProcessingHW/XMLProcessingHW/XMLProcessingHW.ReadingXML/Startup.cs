using System.Xml;

namespace XMLProcessingHW.ReadingXML
{
    public class Startup
    {
        public static void Main()
        {
            var url = "D:\\GitHub\\Homework\\DataBases\\XMLProcessingHW\\XMLProcessingHW\\catalogue.xml";
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(url);

            var doc = xmlDocument.DocumentElement;

            var albums = doc.GetElementsByTagName("album");

            foreach (XmlElement element in albums)
            {
                System.Console.WriteLine(element.ChildNodes[0].InnerText);
                System.Console.WriteLine(element.ChildNodes[1].InnerText);
            }
        }
    }
}
