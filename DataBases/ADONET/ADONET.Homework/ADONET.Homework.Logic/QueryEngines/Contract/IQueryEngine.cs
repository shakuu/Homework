using System.Collections.Generic;
using System.Data;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.QueryEngines.Contract
{
    public interface IQueryEngine
    {
        IConnectionProvider ConnectionProvider { get; set; }

        IEnumerable<ModelType> ExecuteReaderCommand<ModelType>(IDbCommand command)
            where ModelType : new();

        ScalarType ExecuteScalarCommand<ScalarType>(IDbCommand command)
            where ScalarType : struct;

        int ExecuteNonQueryCommand(IDbCommand command);
    }
}
