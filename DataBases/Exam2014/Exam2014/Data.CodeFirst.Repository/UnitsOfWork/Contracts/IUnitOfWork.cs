using Data.CodeFirst.Models;
using Data.CodeFirst.Repository.Repositories.Contracts;


namespace Data.CodeFirst.Repository.UnitsOfWork.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Car> Cars { get; set; }

        IRepository<City> Cities { get; set; }

        IRepository<Dealer> Dealers { get; set; }

        IRepository<Manufacturer> Manufaturers { get; set; }

        int Save();
    }
}
