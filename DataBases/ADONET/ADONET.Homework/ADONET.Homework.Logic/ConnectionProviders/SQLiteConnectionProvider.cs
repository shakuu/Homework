using System;
using System.Data;
using System.Data.SQLite;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class SQLiteConnectionProvider : IConnectionProvider
    {
        public IDbConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            var connection = new SQLiteConnection(connectionString);

            return connection;
        }
    }
}
