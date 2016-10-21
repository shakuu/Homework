using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

using ADONET.Homework.Logic.CommandProviders.Contracts;

namespace ADONET.Homework.Logic.CommandProviders
{
    public class SQLiteCommandProvider : ICommandProvider
    {
        public IDbCommand CreateCommand(string commandString, IDictionary<string, string> parameters = null)
        {
            if (string.IsNullOrEmpty(commandString))
            {
                throw new ArgumentNullException(nameof(commandString));
            }

            var command = new SQLiteCommand(commandString);
            return command;
        }
    }
}
