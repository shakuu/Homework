using System.Collections.Generic;

namespace Data.CodeFirst.Repository.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll();

        TEntity GetById(int id);

        int Add(TEntity entity);
    }
}
