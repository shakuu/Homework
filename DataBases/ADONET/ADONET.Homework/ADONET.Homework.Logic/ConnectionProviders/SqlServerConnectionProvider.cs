using System;
using System.Data;
using System.Data.SqlClient;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class SqlServerConnectionProvider : IConnectionProvider
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            var connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
