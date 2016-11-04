using System.Data.Entity;

using Contracts;
using SqlModels;

namespace SqlServer
{
    public class MessagesDbContext : DbContext, IDbContext
    {
        public MessagesDbContext()
            : base("name=MessagesDb")
        {

        }
        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return this.Set<TEntity>();
        }
    }
}
