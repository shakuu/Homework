using System.Collections.Generic;

namespace JSONProcessingHW.Logic.Parsers.Contracts
{
    public interface IJsonParser<T>
    {
        IEnumerable<T> ExtractValues();
    }
}
