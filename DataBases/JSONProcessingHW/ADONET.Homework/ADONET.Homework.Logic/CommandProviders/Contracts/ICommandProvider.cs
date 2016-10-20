using System.Data;
using System.Collections.Generic;

namespace ADONET.Homework.Logic.CommandProviders.Contracts
{
    public interface ICommandProvider
    {
        IDbCommand CreateCommand(string connectionString, string commandString, IDictionary<string, string> parameters);
    }
}
