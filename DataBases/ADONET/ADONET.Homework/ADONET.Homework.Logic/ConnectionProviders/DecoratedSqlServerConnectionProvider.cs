using System;
using System.Data;

using ADONET.Homework.Logic.ConfigurationProviders.Contracts;
using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class DecoratedSqlServerConnectionProvider : IConnectionProvider
    {
        private readonly IConnectionProvider connectionProvider;
        private readonly IConfigurationProvider configurationProvider;
        private readonly string connectionStringKey;

        private string connectionStringFromConfig;

        public DecoratedSqlServerConnectionProvider(IConnectionProvider connectionProvider, string connectionStringKey, IConfigurationProvider configurationProvider)
        {
            if (connectionProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionProvider));
            }

            if (configurationProvider == null)
            {
                throw new ArgumentNullException(nameof(configurationProvider));
            }

            if (string.IsNullOrEmpty(connectionStringKey))
            {
                throw new ArgumentNullException(nameof(connectionStringKey));
            }

            this.connectionProvider = connectionProvider;
            this.configurationProvider = configurationProvider;

            this.connectionStringKey = connectionStringKey;
        }

        private string ConnectionStringFromConfig
        {
            get
            {
                if (this.connectionStringFromConfig == null)
                {
                    this.connectionStringFromConfig = this.configurationProvider.ReadConfiguration(this.connectionStringKey);
                }

                return this.connectionStringFromConfig;
            }
        }

        public IDbConnection CreateConnection(string connectionString)
        {
            if (connectionString == null)
            {
                connectionString = this.ConnectionStringFromConfig;
            }

            var connection = this.connectionProvider.CreateConnection(connectionString);
            return connection;
        }
    }
}
