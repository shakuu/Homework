using System.Collections.Generic;
using System.Data;

namespace ADONET.Homework.Logic.DataHandlers.Contracts
{
    public interface IDataHandler
    {
        IEnumerable<ModelType> ParseData<ModelType>(IDataReader dataReader) 
            where ModelType : new();
    }
}
