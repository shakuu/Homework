using System;
using System.Collections.Generic;
using System.Data;

using ADONET.Homework.Logic.CommandProviders.Contracts;

using MySql.Data.MySqlClient;

namespace ADONET.Homework.Logic.CommandProviders
{
    public class MySqlCommandProvider : ICommandProvider
    {
        public IDbCommand CreateCommand(string commandString, IDictionary<string, string> parameters = null)
        {
            if (string.IsNullOrEmpty(commandString))
            {
                throw new ArgumentNullException(nameof(commandString));
            }

            var command = new MySqlCommand(commandString);
            return command;
        }
    }
}
