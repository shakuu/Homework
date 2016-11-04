using System.Data.Entity;

using Contracts;
using Models;

namespace SqlServer
{
    public class MessagesDbContext : DbContext, IDbContext
    {
        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return this.Set<TEntity>();
        }
    }
}
