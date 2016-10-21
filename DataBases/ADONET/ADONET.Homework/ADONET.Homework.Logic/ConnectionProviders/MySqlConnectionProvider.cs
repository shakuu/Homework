using System;
using System.Data;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;

using MySql.Data.MySqlClient;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class MySqlConnectionProvider : IConnectionProvider
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            var connection = new MySqlConnection(connectionString);
            return connection;
        }
    }
}
