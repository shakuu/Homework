using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Data.CodeFirst.Repository.Repositories.Contracts;

namespace Data.CodeFirst.Repository.Repositories.Base
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
        }

        public int Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entitySet = this.GetDbSet();
            entitySet.Add(entity);
            var rowsAffected = context.SaveChanges();

            return rowsAffected;
        }

        public ICollection<TEntity> GetAll()
        {
            var entitySet = this.GetDbSet();
            var allItems = entitySet.ToList();

            return allItems;
        }

        public TEntity GetById(int id)
        {
            var entitySet = this.GetDbSet();
            var item = entitySet.Find(id);

            return item;
        }

        private DbSet<TEntity> GetDbSet()
        {
            var set = this.context.Set<TEntity>();
            return set;
        }
    }
}
