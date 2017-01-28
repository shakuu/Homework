using WebFormsDataBinding.Cars.EventsArgs;
using WebFormsDataBinding.Cars.Presenters.Contracts;
using WebFormsDataBinding.Cars.Services.Contracts;
using WebFormsDataBinding.Cars.Views;

using WebFormsMvp;

namespace WebFormsDataBinding.Cars.Presenters
{
    public class CarsPresenter : Presenter<ICarsView>, ICarsPresenter
    {
        private ICarsView view;
        private ICarsService carsService;

        public CarsPresenter(ICarsView view, ICarsService carsService)
            : base(view)
        {
            this.view = view;
            this.view.ChangeSelection += this.OnChangeSelection;
            this.view.InitialState += this.OnInitialState;

            this.carsService = carsService;
        }

        private void OnChangeSelection(object sender, ChangeSelectionEventArgs args)
        {
            this.view.Model.MatchingCars = this.carsService.FindCars(args.SelectedMake, args.SelectedOptions);
        }

        private void OnInitialState(object sender, InitialStateEventArgs args)
        {
            args.AssignMakesDataSource(this.carsService.AllAvailableMakes());
            args.AssignModelsDataSource(this.carsService.AllAvailableModels());
            args.AssignOptionsDataSource(this.carsService.AllAvailableOptions());
        }
    }
}
