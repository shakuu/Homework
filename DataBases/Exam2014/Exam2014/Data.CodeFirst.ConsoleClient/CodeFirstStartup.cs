using Data.CodeFirst.ConsoleClient.QueryFromXml;

namespace Data.CodeFirst.ConsoleClient
{
    public class CodeFirstStartup
    {
        public static void Main()
        {
            //StaticJsonDataParser.ParseJsonData();
            XmlQuery.BuildQueryFromXml(null);
            XmlQuery.BuildQueryContainerFromXml(null);
        }
    }
}
