using System;
using System.Collections.Generic;

using WebFormsDataBinding.Cars.Models;

namespace WebFormsDataBinding.Cars.EventsArgs
{
    public class ChangeSelectionEventArgs : EventArgs
    {
        public ChangeSelectionEventArgs(
            string selectedMake,
            IEnumerable<string> selectedOptions,
            Action<IEnumerable<Car>> assignMatchingCarsDataSource)
        {
            this.SelectedMake = selectedMake;
            this.SelectedOptions = selectedOptions;
            this.AssignMatchingCarsDataSource = assignMatchingCarsDataSource;
        }

        public string SelectedMake { get; set; }

        public IEnumerable<string> SelectedOptions { get; set; }

        public Action<IEnumerable<Car>> AssignMatchingCarsDataSource { get; set; }
    }
}
