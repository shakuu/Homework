using System;
using System.Collections.Generic;

namespace WebFormsDataBinding.Cars.EventsArgs
{
    public class ChangeSelectionEventArgs : EventArgs
    {
        public ChangeSelectionEventArgs(string selectedMake, IEnumerable<string> selectedOptions)
        {
            this.SelectedMake = selectedMake;
            this.SelectedOptions = selectedOptions;
        }

        public string SelectedMake { get; set; }

        public IEnumerable<string> SelectedOptions { get; set; }
    }
}
