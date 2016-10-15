using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json.Linq;

using JSONProcessingHW.Logic.Models.Contracts;
using JSONProcessingHW.Logic.Parsers.Contracts;

namespace JSONProcessingHW.Logic.Parsers
{
    public class JsonParser<T> : IJsonParser<T> where T : class, IModel
    {
        public IEnumerable<T> ParseJson(string json, string rootName, string elementName)
        {
            var jsonObject = JObject.Parse(json);
            var elements = jsonObject.SelectToken(rootName).SelectTokens(elementName);

            var result = elements.Children().Select(el => new
            {
                Title = (string)el.SelectToken("title"),
                Url = (string)el.SelectToken("link").SelectToken("@href")
            } as T)
            .ToList();

            return result;
        }
    }
}
