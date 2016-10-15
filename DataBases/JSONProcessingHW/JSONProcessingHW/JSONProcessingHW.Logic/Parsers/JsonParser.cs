using System;
using System.Collections.Generic;
using System.Linq;

using JSONProcessingHW.Logic.Models.Contracts;
using JSONProcessingHW.Logic.Parsers.Contracts;

using Newtonsoft.Json.Linq;

namespace JSONProcessingHW.Logic.Parsers
{
    public class JsonParser<ModelType> : IJsonParser<ModelType> where ModelType : IModel, new()
    {
        public IEnumerable<ModelType> ParseJson(string json, string rootName, string elementName)
        {
            if (json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            if (rootName == null)
            {
                throw new ArgumentNullException(nameof(rootName));
            }

            if (elementName == null)
            {
                throw new ArgumentNullException(nameof(elementName));
            }

            var jsonObject = JObject.Parse(json);
            var rootElement = jsonObject.SelectToken(rootName);
            var modelElements = rootElement.SelectTokens(elementName);

            var modelElementsChildren = modelElements.Children();
            var result = modelElementsChildren.Select(el => new ModelType
            {
                Title = (string)el.SelectToken("title"),
                Url = (string)el.SelectToken("link").SelectToken("@href")
            })
            .ToList();

            return result;
        }
    }
}
