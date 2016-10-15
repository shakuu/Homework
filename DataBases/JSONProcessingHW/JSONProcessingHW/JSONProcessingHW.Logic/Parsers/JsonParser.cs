using Newtonsoft.Json.Linq;

namespace JSONProcessingHW.Logic.Parsers
{
    public class JsonParser
    {
        public void ParseJson(string json, string rootName, string elmentName)
        {
            var jsonObject = JObject.Parse(json);
            var elements = jsonObject[rootName];
        }
    }
}
