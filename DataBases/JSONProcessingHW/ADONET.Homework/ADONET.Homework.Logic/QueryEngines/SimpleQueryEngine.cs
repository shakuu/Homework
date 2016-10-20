using System;
using System.Collections.Generic;
using System.Data;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;
using ADONET.Homework.Logic.DataHandlers.Contracts;
using ADONET.Homework.Logic.QueryEngines.Contract;
using ADONET.Homework.Logic.QueryServices.Contracts;

namespace ADONET.Homework.Logic.QueryEngines
{
    public class SimpleQueryEngine : IQueryEngine
    {
        private readonly IQueryService queryService;
        private readonly IDataHandler dataHandler;
        private readonly IConnectionProvider connectionProvider;

        public SimpleQueryEngine(IConnectionProvider connectionProvider, IQueryService queryService, IDataHandler dataHandler)
        {
            if (queryService == null)
            {
                throw new ArgumentNullException(nameof(queryService));
            }

            if (dataHandler == null)
            {
                throw new ArgumentNullException(nameof(dataHandler));
            }

            if (connectionProvider == null)
            {
                throw new ArgumentNullException(nameof(connectionProvider));
            }

            this.queryService = queryService;
            this.dataHandler = dataHandler;
            this.connectionProvider = connectionProvider;
        }

        public IEnumerable<ModelType> ExecuteCommand<ModelType>(IDbCommand command)
            where ModelType : new()
        {
            var connection = this.connectionProvider.CreateConnection(null);
            command.Connection = connection;

            connection.Open();
            var reader = this.queryService.ExecuteReaderQuery(command);
            var parsedData = this.dataHandler.ParseData<ModelType>(reader);
            connection.Close();

            return parsedData;
        }
    }
}
