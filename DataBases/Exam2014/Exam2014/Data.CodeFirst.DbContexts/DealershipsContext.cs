using System.Data.Entity;

using Data.CodeFirst.Models;

namespace Data.CodeFirst.DbContexts
{
    public class DealershipsContext : DbContext
    {
        public DealershipsContext()
            : base("name=DealershipsDb")
        {

        }

        public virtual IDbSet<Dealer> Dealers { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }

        public virtual IDbSet<Car> Cars { get; set; }
    }
}
