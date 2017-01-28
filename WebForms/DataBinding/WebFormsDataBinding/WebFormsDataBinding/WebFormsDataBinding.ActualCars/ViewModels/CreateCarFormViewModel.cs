using System.Collections.Generic;

using WebFormsDataBinding.ActualCars.Models.Contracts;

namespace WebFormsDataBinding.ActualCars.ViewModels
{
    public class CreateCarFormViewModel
    {
        public IEnumerable<ICarModel> CreatedCar { get; set; }

        public IEnumerable<string> AvailableMakes { get; set; }

        public IEnumerable<string> AvailableModels { get; set; }

        public IEnumerable<string> AvailableOptions { get; set; }
    }
}
