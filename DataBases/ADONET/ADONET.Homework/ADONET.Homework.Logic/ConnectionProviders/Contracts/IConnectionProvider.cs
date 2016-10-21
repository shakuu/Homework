using System.Data;

namespace ADONET.Homework.Logic.ConnectionProviders.Contracts
{
    public interface IConnectionProvider
    {
        IDbConnection CreateConnection(string connectionString);
    }
}
