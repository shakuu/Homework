using System;
using System.Data;

using ADONET.Homework.Logic.ConfigurationProviders.Contracts;
using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class DecoratedSqlServerConnectionProvider : IConnectionProvider
    {
        private IConnectionProvider connectionProvider;
        private IConfigurationProvider configurationProvider;

        public DecoratedSqlServerConnectionProvider(IConnectionProvider connectionProvider, IConfigurationProvider configurationProvider)
        {
            if (connectionProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionProvider));
            }

            if (configurationProvider == null)
            {
                throw new ArgumentNullException(nameof(configurationProvider));
            }

            this.connectionProvider = connectionProvider;
            this.configurationProvider = configurationProvider;
        }

        public IDbConnection CreateConnection(string connectionString)
        {
            if (connectionString == null)
            {
                connectionString = this.configurationProvider.ReadConfiguration("DefaultConnectionString");
            }

            var connection = this.connectionProvider.CreateConnection(connectionString);
            return connection;
        }
    }
}
