using System;

namespace WebFormsDataBinding.ActualCars.EventsArgs
{
    public class MakeSelectionChangedEventArgs : EventArgs
    {
        public MakeSelectionChangedEventArgs(string selectedMake)
        {
            this.SelectedMake = selectedMake;
        }

        public string SelectedMake { get; set; }
    }
}
