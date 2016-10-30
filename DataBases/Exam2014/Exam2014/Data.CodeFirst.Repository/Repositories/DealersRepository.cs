using System.Data.Entity;

using Data.CodeFirst.Models;
using Data.CodeFirst.Repository.Repositories.Base;

namespace Data.CodeFirst.Repository.Repositories
{
    public class DealersRepository : GenericRepository<Dealer>
    {
        public DealersRepository(DbContext context)
            : base(context)
        {
        }
    }
}
