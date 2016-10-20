using System;
using System.Collections.Generic;
using System.Data;

using ADONET.Homework.Logic.CommandProviders.Contracts;

namespace ADONET.Homework.Logic.CommandProviders
{
    public class CommandProvider : ICommandProvider
    {
        public IDbCommand CreateCommand(string connectionString, string commandString, IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
