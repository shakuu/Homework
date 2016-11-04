using System.Data.Entity;

using Models;
using Repositories.Base;

namespace Repositories
{
    public class UsersRepository : GenericRepository<User>
    {
        public UsersRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
