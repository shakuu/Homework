using System;
using System.Data;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class DefaultMySqlConnectionProvider : IDefaultConnectionProvider
    {
        private const string ConnectionString = "Server=localhost; port=3306; database=library; UID=randomuser; password=12345";

        private readonly IConnectionProvider decoratedProvider;

        public DefaultMySqlConnectionProvider(IConnectionProvider decoratedProvider)
        {
            if (decoratedProvider == null)
            {
                throw new ArgumentNullException(nameof(decoratedProvider));
            }

            this.decoratedProvider = decoratedProvider;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = DefaultMySqlConnectionProvider.ConnectionString;
            var connection = this.decoratedProvider.CreateConnection(connectionString);

            return connection;
        }
    }
}
