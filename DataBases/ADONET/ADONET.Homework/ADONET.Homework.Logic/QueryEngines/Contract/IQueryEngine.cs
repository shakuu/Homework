using System.Collections.Generic;
using System.Data;

namespace ADONET.Homework.Logic.QueryEngines.Contract
{
    public interface IQueryEngine
    {
        IEnumerable<ModelType> ExecuteReaderCommand<ModelType>(IDbCommand command)
            where ModelType : new();

        ScalarType ExecuteScalarCommand<ScalarType>(IDbCommand command)
            where ScalarType : struct;
    }
}
