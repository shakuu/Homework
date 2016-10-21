using System;
using System.Data;

using ADONET.Homework.Logic.QueryServices.Contracts;

namespace ADONET.Homework.Logic.QueryServices
{
    public class QueryService : IQueryService
    {
        public IDataReader ExecuteReaderQuery(IDbCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var reader = command.ExecuteReader();

            return reader;
        }
    }
}
