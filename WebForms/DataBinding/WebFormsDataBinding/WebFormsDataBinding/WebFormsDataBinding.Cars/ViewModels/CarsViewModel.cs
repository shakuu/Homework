using System.Collections.Generic;

using WebFormsDataBinding.Cars.Models;

namespace WebFormsDataBinding.Cars.ViewModels
{
    public class CarsViewModel
    {
        public string SelectedMake { get; set; }

        public IEnumerable<string> AvailableMakes { get; set; }

        public IEnumerable<string> AvailableModels { get; set; }

        public IEnumerable<string> AvailableOptions { get; set; }

        public IEnumerable<Car> MatchingCars { get; set; }
    }
}
