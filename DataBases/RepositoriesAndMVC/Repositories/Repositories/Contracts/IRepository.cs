using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll<TOut>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOut>> select);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
