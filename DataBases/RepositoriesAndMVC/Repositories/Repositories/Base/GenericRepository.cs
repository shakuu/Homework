using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Repositories.Contracts;
using Contracts;

namespace Repositories.Base
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
    {
        private readonly IDbContext context;

        public GenericRepository(IDbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll<TOut>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOut>> select)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
