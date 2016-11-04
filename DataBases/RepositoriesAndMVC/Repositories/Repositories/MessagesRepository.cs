using System.Data.Entity;

using SqlModels;
using Repositories.Base;

namespace Repositories
{
    public class MessagesRepository : GenericRepository<Message>
    {
        public MessagesRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
