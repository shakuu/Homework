using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ADONET.Homework.Logic.CommandProviders.Contracts;

namespace ADONET.Homework.Logic.CommandProviders
{
    public class SqlCommandProvider : ICommandProvider
    {
        public IDbCommand CreateCommand(string commandString, IDictionary<string, string> parameters = null)
        {
            if (string.IsNullOrEmpty(commandString))
            {
                throw new ArgumentNullException(nameof(commandString));
            }

            var command = new SqlCommand(commandString);

            var parametersExist = parameters != null;
            if (parametersExist)
            {
                command = this.CreateParameters(command, parameters);
            }

            return command;
        }

        private SqlCommand CreateParameters(SqlCommand command, IDictionary<string, string> commandsToParse)
        {
            foreach (var item in commandsToParse)
            {
                command.Parameters.AddWithValue(item.Key, item.Value);
            }

            return command;
        }
    }
}
