using JSONProcessingHW.Logic.Models.Contracts;
using System.Collections.Generic;

namespace JSONProcessingHW.Logic.Parsers.Contracts
{
    public interface IJsonParser
    {
        IEnumerable<ModelType> ParseJson<ModelType>(string json, string rootName, string elementName) 
            where ModelType : IModel, new();
    }
}
