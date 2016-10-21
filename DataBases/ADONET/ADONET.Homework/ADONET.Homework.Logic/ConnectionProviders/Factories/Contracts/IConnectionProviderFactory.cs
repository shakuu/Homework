using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders.Factories.Contracts
{
    public interface IConnectionProviderFactory
    {
        IConnectionProvider GetConnectionProvider(string key);
    }
}
