using System.Data.Entity;

using Data.CodeFirst.Repository.Repositories.Base;
using Data.CodeFirst.Models;

namespace Data.CodeFirst.Repository.Repositories
{
    public class CarsRepository : GenericRepository<Car>
    {
        public CarsRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
