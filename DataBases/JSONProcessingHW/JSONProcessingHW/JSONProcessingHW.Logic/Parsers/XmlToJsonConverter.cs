using System.Xml;

using Newtonsoft.Json;

using JSONProcessingHW.Logic.Parsers.Contracts;

namespace JSONProcessingHW.Logic.Parsers
{
    public class XmlToJsonConverter : IXmlToJsonConverter
    {
        public string ConvertXmlToJson(XmlDocument xmlDocument)
        {
            var json = JsonConvert.SerializeXmlNode(xmlDocument);
            return json;
        }
    }
}
