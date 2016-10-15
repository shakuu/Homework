using System.Collections.Generic;

using JSONProcessingHW.Logic.Models.Contracts;

namespace JSONProcessingHW.Logic.Parsers.Contracts
{
    public interface IJsonParser<T>
    {
        IEnumerable<T> ParseJson(string json, string rootName, string elementName);
    }
}
