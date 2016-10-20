using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ADONET.Homework.Logic.CommandProviders.Contracts;

namespace ADONET.Homework.Logic.CommandProviders
{
    public class CommandProvider : ICommandProvider
    {
        public IDbCommand CreateCommand(string commandString, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(commandString))
            {
                throw new ArgumentNullException(nameof(commandString));
            }

            var command = new SqlCommand(commandString);

            var parametersExist = parameters != null;
            if (parametersExist)
            {
                // TODO: Parse parameters
            }

            return command;
        }
    }
}
