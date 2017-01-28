using System.Collections.Generic;

using WebFormsDataBinding.ActualCars.Models.Contracts;

namespace WebFormsDataBinding.ActualCars.Models.Factories
{
    public interface ICreateCarFormModelsFactory
    {
        ICarModel CreateCarModel(string make, string model, IEnumerable<string> options);
    }
}
