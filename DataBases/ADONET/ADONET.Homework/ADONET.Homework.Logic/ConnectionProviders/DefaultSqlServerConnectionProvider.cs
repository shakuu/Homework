using System;
using System.Data;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class DefaultSqlServerConnectionProvider : IDefaultConnectionProvider
    {
        private const string ConnectionString = "Server=.;Database=Northwind;Integrated Security = true";

        private readonly IConnectionProvider decoratedProvider;

        public DefaultSqlServerConnectionProvider(IConnectionProvider decoratedProvider)
        {
            if (decoratedProvider == null)
            {
                throw new ArgumentNullException(nameof(decoratedProvider));
            }

            this.decoratedProvider = decoratedProvider;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = DefaultSqlServerConnectionProvider.ConnectionString;
            var connection = this.decoratedProvider.CreateConnection(connectionString);

            return connection;
        }
    }
}
