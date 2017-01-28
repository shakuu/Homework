using System;
using WebFormsDataBinding.ActualCars.EventsArgs;
using WebFormsDataBinding.ActualCars.ViewModels;

using WebFormsMvp;

namespace WebFormsDataBinding.ActualCars.Views
{
    public interface ICreateCarFormView : IView<CreateCarFormViewModel>
    {
        event EventHandler<MakeSelectionChangedEventArgs> MakeSelectionChanged;

        event EventHandler<CreateCarFormSubmitEventArgs> CreateCarFormSubmit;
    }
}
