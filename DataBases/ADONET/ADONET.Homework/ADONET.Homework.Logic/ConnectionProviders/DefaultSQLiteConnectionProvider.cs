using System;
using System.Data;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class DefaultSQLiteConnectionProvider : IConnectionProvider
    {
        private const string ConnectionString = "Data Source=../../../../homework.sqlite;Version=3;";

        private readonly IConnectionProvider decoratedProvider;

        public DefaultSQLiteConnectionProvider(IConnectionProvider decoratedProvider)
        {
            if (decoratedProvider == null)
            {
                throw new ArgumentNullException(nameof(decoratedProvider));
            }

            this.decoratedProvider = decoratedProvider;
        }

        public IDbConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = DefaultSQLiteConnectionProvider.ConnectionString;
            }

            var connection = this.decoratedProvider.CreateConnection(connectionString);

            return connection;
        }
    }
}
