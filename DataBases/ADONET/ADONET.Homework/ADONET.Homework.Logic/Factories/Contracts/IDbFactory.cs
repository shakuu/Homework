using ADONET.Homework.Logic.CommandProviders.Contracts;
using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.Factories.Contracts
{
    public interface IDbFactory
    {
        ICommandProvider CreateCommandProvider(string key);

        IConnectionProvider CreateConnectionProvider(string key);
    }
}
