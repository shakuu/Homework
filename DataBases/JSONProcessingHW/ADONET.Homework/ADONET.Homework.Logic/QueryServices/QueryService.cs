using System;
using System.Data;

using ADONET.Homework.Logic.QueryServices.Contracts;

namespace ADONET.Homework.Logic.QueryServices
{
    public class QueryService : IQueryService
    {
        public IDataReader ExecuteReaderQuery(IDbCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
