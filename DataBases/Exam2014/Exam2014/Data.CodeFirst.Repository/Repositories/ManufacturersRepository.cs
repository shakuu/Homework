using System.Data.Entity;

using Data.CodeFirst.Models;
using Data.CodeFirst.Repository.Repositories.Base;

namespace Data.CodeFirst.Repository.Repositories
{
    public class ManufacturersRepository : GenericRepository<Manufacturer>
    {
        public ManufacturersRepository(DbContext context)
            : base(context)
        {
        }
    }
}
