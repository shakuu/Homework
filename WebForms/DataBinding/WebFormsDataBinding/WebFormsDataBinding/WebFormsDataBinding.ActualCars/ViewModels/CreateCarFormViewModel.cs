using System.Collections.Generic;

namespace WebFormsDataBinding.ActualCars.ViewModels
{
    public class CreateCarFormViewModel
    {
        public IEnumerable<string> AvailableMakes { get; set; }

        public IEnumerable<string> AvailableModels { get; set; }

        public IEnumerable<string> AvailableOptions { get; set; }
    }
}
