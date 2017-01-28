using System;
using System.Collections.Generic;

namespace WebFormsDataBinding.ActualCars.EventsArgs
{
    public class CreateCarFormSubmitEventArgs : EventArgs
    {
        public string SelectedMake { get; set; }

        public string SelectedModel { get; set; }

        public IEnumerable<string> SelectedOptions { get; set; }
    }
}
