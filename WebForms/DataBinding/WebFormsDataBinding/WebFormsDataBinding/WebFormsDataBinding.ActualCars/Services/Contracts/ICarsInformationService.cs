using System.Collections.Generic;

using WebFormsDataBinding.ActualCars.Models.Contracts;

namespace WebFormsDataBinding.ActualCars.Services.Contracts
{
    public interface ICarsInformationService
    {
        IEnumerable<ICarModel> FindOrCreateCar(string make, string model, ICollection<string> options);

        IEnumerable<string> FindAvailableMakes();

        IEnumerable<string> FindAvaialbleModels(string make = null);

        IEnumerable<string> FindAvailableOptions();
    }
}
