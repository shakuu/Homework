using System;
using System.Collections.Generic;

namespace WebFormsDataBinding.Cars.EventsArgs
{
    public class InitialStateEventArgs : EventArgs
    {
        public InitialStateEventArgs(
            Action<IEnumerable<string>> assignMakesDataSource,
            Action<IEnumerable<string>> assignModelsDataSource,
            Action<IEnumerable<string>> assignOptionsDataSource)
        {
            this.AssignMakesDataSource = assignMakesDataSource;
            this.AssignModelsDataSource = assignModelsDataSource;
            this.AssignOptionsDataSource = assignOptionsDataSource;
        }

        public Action<IEnumerable<string>> AssignMakesDataSource { get; set; }

        public Action<IEnumerable<string>> AssignModelsDataSource { get; set; }

        public Action<IEnumerable<string>> AssignOptionsDataSource { get; set; }
    }
}
