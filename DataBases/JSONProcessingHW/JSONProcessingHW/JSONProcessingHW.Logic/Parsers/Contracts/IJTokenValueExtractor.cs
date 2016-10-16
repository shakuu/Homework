using Newtonsoft.Json.Linq;

namespace JSONProcessingHW.Logic.Parsers.Contracts
{
    public interface IJTokenValueExtractor
    {
        string ExtractJTokenValue(JToken token);
    }
}
