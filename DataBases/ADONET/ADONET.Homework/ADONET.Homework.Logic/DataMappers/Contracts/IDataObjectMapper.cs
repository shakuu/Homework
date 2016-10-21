using System.Collections.Generic;
using System.Data;

namespace ADONET.Homework.Logic.DataMappers.Contracts
{
    public interface IDataObjectMapper
    {
        IEnumerable<ModelType> ParseData<ModelType>(IDataReader dataReader) 
            where ModelType : new();
    }
}
