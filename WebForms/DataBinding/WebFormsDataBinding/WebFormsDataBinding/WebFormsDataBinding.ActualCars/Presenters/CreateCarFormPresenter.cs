using System;

using WebFormsDataBinding.ActualCars.EventsArgs;
using WebFormsDataBinding.ActualCars.Presenters.Contracts;
using WebFormsDataBinding.ActualCars.Services.Contracts;
using WebFormsDataBinding.ActualCars.Views;

using WebFormsMvp;

namespace WebFormsDataBinding.ActualCars.Presenters
{
    public class CreateCarFormPresenter : Presenter<ICreateCarFormView>, ICreateCarFormPresenter
    {
        private readonly ICreateCarFormView view;
        private readonly ICarsInformationService carsInformationService;

        public CreateCarFormPresenter(ICreateCarFormView view, ICarsInformationService carsInformationService)
            : base(view)
        {
            this.view = view;

            this.view.MakeSelectionChanged += this.OnMakeSelectionChanged;
            this.view.CreateCarFormSubmit += this.OnCreateCarFormSubmit;
            this.view.InitialState += this.OnInitialState;

            this.carsInformationService = carsInformationService;
        }

        private void OnInitialState(object sender, EventArgs args)
        {
            this.view.Model.AvailableMakes = this.carsInformationService.FindAvailableMakes();
            this.view.Model.AvailableModels = this.carsInformationService.FindAvaialbleModels();
            this.view.Model.AvailableOptions = this.carsInformationService.FindAvailableOptions();
        }

        private void OnMakeSelectionChanged(object sender, MakeSelectionChangedEventArgs args)
        {
            this.view.Model.AvailableModels = this.carsInformationService.FindAvaialbleModels(args.SelectedMake);
        }

        private void OnCreateCarFormSubmit(object sender, CreateCarFormSubmitEventArgs args)
        {
            this.view.Model.CreatedCar = this.carsInformationService.FindOrCreateCar(args.SelectedMake, args.SelectedModel, args.SelectedOptions);
        }
    }
}
