using System.Collections.Generic;

namespace JSONProcessingHW.Logic.Parsers.Contracts
{
  public  interface IJTokenValueExtractorProvider
    {
        IJTokenValueExtractor CreateJTokenValueExtractor(IEnumerable<string> elementSignature);
    }
}
