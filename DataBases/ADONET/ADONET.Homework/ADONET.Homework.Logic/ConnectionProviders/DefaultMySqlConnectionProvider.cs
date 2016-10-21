using System;
using System.Data;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class DefaultMySqlConnectionProvider : IConnectionProvider
    {
        private const string ConnectionString = "";

        private readonly IConnectionProvider decoratedProvider;

        public DefaultMySqlConnectionProvider(IConnectionProvider decoratedProvider)
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
                connectionString = DefaultMySqlConnectionProvider.ConnectionString;
            }

            var connection = this.decoratedProvider.CreateConnection(connectionString);

            return connection;
        }
    }
}
