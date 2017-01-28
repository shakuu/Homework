using WebFormsDataBinding.ActualCars.Presenters.Contracts;
using WebFormsDataBinding.ActualCars.Views;

using WebFormsMvp;

namespace WebFormsDataBinding.ActualCars.Presenters
{
    public class CreateCarFormPresenter : Presenter<ICreateCarFormView>, ICreateCarFormPresenter
    {
        private readonly ICreateCarFormView view;

        public CreateCarFormPresenter(ICreateCarFormView view)
            : base(view)
        {
            this.view = view;

            //this.view.MakeSelectionChanged;
            //this.view.CreateCarFormSubmit;
            //this.view.InitialState;
        }
    }
}
