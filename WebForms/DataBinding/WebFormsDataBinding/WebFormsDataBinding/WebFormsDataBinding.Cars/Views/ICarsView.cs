using System;

using WebFormsDataBinding.Cars.EventsArgs;
using WebFormsDataBinding.Cars.ViewModels;

using WebFormsMvp;

namespace WebFormsDataBinding.Cars.Views
{
    public interface ICarsView : IView<CarsViewModel>
    {
        event EventHandler<ChangeSelectionEventArgs> ChangeSelection;

        event EventHandler<InitialStateEventArgs> InitialState;
    }
}
