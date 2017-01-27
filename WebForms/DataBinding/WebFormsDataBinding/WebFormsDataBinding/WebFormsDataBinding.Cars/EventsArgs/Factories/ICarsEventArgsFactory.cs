using System;
using System.Collections.Generic;

namespace WebFormsDataBinding.Cars.EventsArgs.Factories
{
    public interface ICarsEventArgsFactory
    {
        ChangeSelectionEventArgs CreateCarsChangeMakeEventArgs(string selectedMake, IEnumerable<string> selectedOptions);

        InitialStateEventArgs CreateInitialStateEventArgs(
            Action<IEnumerable<string>> assignMakesDataSource,
            Action<IEnumerable<string>> assignModelsDataSource,
            Action<IEnumerable<string>> assignOptionsDataSource);
    }
}
