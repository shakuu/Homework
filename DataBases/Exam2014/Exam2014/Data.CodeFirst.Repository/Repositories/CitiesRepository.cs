using System.Data.Entity;

using Data.CodeFirst.Repository.Repositories.Base;
using Data.CodeFirst.Models;

namespace Data.CodeFirst.Repository.Repositories
{
    public class CitiesRepository : GenericRepository<City>
    {
        public CitiesRepository(DbContext context)
            : base(context)
        {
        }
    }
}
