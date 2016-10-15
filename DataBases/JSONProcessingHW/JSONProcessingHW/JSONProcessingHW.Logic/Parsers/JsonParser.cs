using System.Collections.Generic;
using System.Linq;

using JSONProcessingHW.Logic.Models.Contracts;
using JSONProcessingHW.Logic.Parsers.Contracts;

using Newtonsoft.Json.Linq;

namespace JSONProcessingHW.Logic.Parsers
{
    public class JsonParser<T> : IJsonParser<T> where T : IModel, new()
    {
        public IEnumerable<T> ParseJson(string json, string rootName, string elementName)
        {
            var jsonObject = JObject.Parse(json);
            var elements = jsonObject.SelectToken(rootName).SelectTokens(elementName);

            var result = elements.Children().Select(el => new T
            {
                Title = (string)el.SelectToken("title"),
                Url = (string)el.SelectToken("link").SelectToken("@href")
            })
            .ToList();

            return result;
        }
    }
}
