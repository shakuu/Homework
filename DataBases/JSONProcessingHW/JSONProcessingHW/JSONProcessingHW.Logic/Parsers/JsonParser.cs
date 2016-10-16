using System;
using System.Collections.Generic;
using System.Linq;

using JSONProcessingHW.Logic.Models.Contracts;
using JSONProcessingHW.Logic.Parsers.Contracts;

using Newtonsoft.Json.Linq;

namespace JSONProcessingHW.Logic.Parsers
{
    public class JsonParser : IJsonParser
    {
        public IEnumerable<ModelType> ParseJson<ModelType>(
            string json,
            string rootName,
            string elementName,
            IJTokenValueExtractor titleExtractor,
            IJTokenValueExtractor urlExtractor)
            where ModelType : IModel, new()
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

            if (titleExtractor == null)
            {
                throw new ArgumentNullException(nameof(titleExtractor));
            }

            if (urlExtractor == null)
            {
                throw new ArgumentNullException(nameof(urlExtractor));
            }

            var jsonObject = JObject.Parse(json);
            var rootElement = jsonObject.SelectToken(rootName);
            var contentElements = rootElement.SelectTokens(elementName);

            var contentElementsChildren = contentElements.Children();
            var result = contentElementsChildren.Select(element => new ModelType
            {
                Title = titleExtractor.ExtractJTokenValue(element),
                Url = urlExtractor.ExtractJTokenValue(element)
            })
                .ToList();

            return result;
        }
    }
}
