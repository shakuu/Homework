using System.Data;

namespace ADONET.Homework.Logic.ConnectionProviders.Contracts
{
    public interface IDefaultConnectionProvider
    {
        IDbConnection CreateConnection();
    }
}
