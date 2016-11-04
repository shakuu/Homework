using System.Data.Entity;

namespace Contracts
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
