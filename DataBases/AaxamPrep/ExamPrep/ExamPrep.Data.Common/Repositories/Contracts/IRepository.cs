using System.Collections.Generic;

namespace ExamPrep.Data.Common.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All();

        TEntity Find(object id);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}
