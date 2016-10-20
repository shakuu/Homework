using System.Data;
using System.Data.SqlClient;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class DefaultSqlServerConnectionProvider : IConnectionProvider
    {
        private const string ConnectionString = "Server=.;Database=Northwind;Integrated Security = true";

        public IDbConnection CreateConnection(string connectionString)
        {
            if (connectionString == null)
            {
                connectionString = DefaultSqlServerConnectionProvider.ConnectionString;
            }

            var connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
