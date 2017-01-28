using System;

namespace WebFormsDataBinding.ActualCars.EventsArgs
{
    public class MakeSelectionChangedEventArgs : EventArgs
    {
        public string SelectedMake { get; set; }
    }
}
