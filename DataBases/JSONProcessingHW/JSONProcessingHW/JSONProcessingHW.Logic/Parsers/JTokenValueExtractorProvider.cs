using System.Collections.Generic;

using JSONProcessingHW.Logic.Parsers.Contracts;

namespace JSONProcessingHW.Logic.Parsers
{
    public class JTokenValueExtractorProvider : IJTokenValueExtractorProvider
    {
        public IJTokenValueExtractor CreateJTokenValueExtractor(IEnumerable<string> elementSignature)
        {
            var jTokenValueExtractor = new JTokenValueExtractor(elementSignature);
            return jTokenValueExtractor;
        }
    }
}
