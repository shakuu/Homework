﻿using System;
using System.Collections.Generic;

namespace WebFormsDataBinding.ActualCars.EventsArgs
{
    public class CreateCarFormSubmitEventArgs : EventArgs
    {
        public CreateCarFormSubmitEventArgs(string selectedMake, string selectedModel, ICollection<string> selectedOptions)
        {
            this.SelectedMake = selectedMake;
            this.SelectedModel = selectedModel;
            this.SelectedOptions = selectedOptions;
        }

        public string SelectedMake { get; set; }

        public string SelectedModel { get; set; }

        public ICollection<string> SelectedOptions { get; set; }
    }
}
