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

        public ScalarType ExecuteScalarQuery<ScalarType>(IDbCommand command)
            where ScalarType : struct
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var scalar = command.ExecuteScalar();
            var result = (ScalarType)scalar;

            return result;
        }

        public int ExecuteNonQuery(IDbCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var rowsAffected = command.ExecuteNonQuery();

            return rowsAffected;
        }
    }
}
