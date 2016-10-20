using System.Collections.Generic;
using System.Data;

namespace ADONET.Homework.Logic.QueryEngines.Contract
{
    public interface IQueryEngine
    {
        IEnumerable<ModelType> ExecuteCommand<ModelType>(IDbCommand command)
            where ModelType : new();
    }
}
