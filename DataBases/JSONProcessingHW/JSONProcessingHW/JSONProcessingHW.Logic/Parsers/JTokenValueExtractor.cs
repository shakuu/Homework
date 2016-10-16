using System;
using System.Collections.Generic;

using JSONProcessingHW.Logic.Parsers.Contracts;
using Newtonsoft.Json.Linq;

namespace JSONProcessingHW.Logic.Parsers
{
    public class JTokenValueExtractor : IJTokenValueExtractor
    {
        private readonly IEnumerable<string> elementSignature;

        public JTokenValueExtractor(IEnumerable<string> elementSignature)
        {
            if (elementSignature == null)
            {
                throw new ArgumentNullException(nameof(elementSignature));
            }

            this.elementSignature = elementSignature;
        }

        public string ExtractJTokenValue(JToken token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            var extractedToken = token;
            foreach (var element in this.elementSignature)
            {
                extractedToken = extractedToken.SelectToken(element);
            }

            var value = (string)extractedToken;
            return value;
        }
    }
}
