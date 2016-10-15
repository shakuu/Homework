using System.Collections.Generic;

using JSONProcessingHW.Logic.Models.Contracts;

namespace JSONProcessingHW.Logic.Parsers.Contracts
{
    public interface IJsonParser<T> where T : class, IModel
    {
        IEnumerable<T> ParseJson(string json, string rootName, string elementName);
    }
}
