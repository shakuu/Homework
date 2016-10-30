using Data.CodeFirst.Models;
using Data.CodeFirst.DbContexts;
using Data.CodeFirst.Repository.Repositories;
using Data.CodeFirst.Repository.Repositories.Contracts;
using Data.CodeFirst.Repository.UnitsOfWork.Contracts;

namespace Data.CodeFirst.Repository.UnitsOfWork
{
    public class CarsUnitOfWork : IUnitOfWork
    {
        private readonly DealershipsContext context;

        public CarsUnitOfWork(DealershipsContext context)
        {
            this.context = context;

            this.Cars = new CarsRepository(context);
            this.Cities = new CitiesRepository(context);
            this.Dealers = new DealersRepository(context);
            this.Manufaturers = new ManufacturersRepository(context);
        }

        public IRepository<Car> Cars { get; set; }

        public IRepository<City> Cities { get; set; }

        public IRepository<Dealer> Dealers { get; set; }

        public IRepository<Manufacturer> Manufaturers { get; set; }

        public int Save()
        {
            var rowsAffected = this.context.SaveChanges();
            return rowsAffected;
        }
    }
}
