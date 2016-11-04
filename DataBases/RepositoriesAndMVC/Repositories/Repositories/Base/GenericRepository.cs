using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using Repositories.Contracts;

namespace Repositories.Base
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            var entry = this.context.Entry(entities);
            entry.State = EntityState.Added;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetAll<TOut>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOut>> select)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
