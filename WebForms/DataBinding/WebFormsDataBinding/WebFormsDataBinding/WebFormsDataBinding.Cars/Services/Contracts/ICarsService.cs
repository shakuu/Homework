using System.Collections.Generic;

using WebFormsDataBinding.Cars.Models;

namespace WebFormsDataBinding.Cars.Services.Contracts
{
    public interface ICarsService
    {
        IEnumerable<Car> FindCars(string make, IEnumerable<string> options);

        IEnumerable<string> AllAvailableMakes();

        IEnumerable<string> AllAvailableModels(string make = null);

        IEnumerable<string> AllAvailableOptions();

    }
}
