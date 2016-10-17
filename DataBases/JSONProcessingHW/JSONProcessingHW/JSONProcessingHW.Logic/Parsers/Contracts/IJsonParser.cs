using System;
using System.Collections.Generic;

using JSONProcessingHW.Logic.Models.Contracts;

using Newtonsoft.Json.Linq;

namespace JSONProcessingHW.Logic.Parsers.Contracts
{
    public interface IJsonParser
    {
        IEnumerable<ModelType> ParseJson<ModelType>(string json, string rootName, string elementName, IJTokenValueExtractor titleExtractor, IJTokenValueExtractor urlExtractor)
            where ModelType : ITitleUrlModel, new();
    }
}
