using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using WebFormsDataBinding.ActualCars.EventsArgs;
using WebFormsDataBinding.ActualCars.Presenters.Contracts;
using WebFormsDataBinding.ActualCars.ViewModels;
using WebFormsDataBinding.ActualCars.Views;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsDataBinding.WebClient.UserControls
{
    [PresenterBinding(typeof(ICreateCarFormPresenter))]
    public partial class ActualCarsUserControl : MvpUserControl<CreateCarFormViewModel>, ICreateCarFormView
    {
        public event EventHandler<CreateCarFormSubmitEventArgs> CreateCarFormSubmit;
        public event EventHandler<MakeSelectionChangedEventArgs> MakeSelectionChanged;
        public event EventHandler InitialState;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.InitialState?.Invoke(null, null);

                this.Makes.DataSource = this.Model.AvailableMakes;
                this.Makes.DataBind();

                this.Models.DataSource = this.Model.AvailableModels;
                this.Models.DataBind();

                this.Options.DataSource = this.Model.AvailableOptions;
                this.Options.DataBind();
            }
        }

        protected void OnMakeSelectionChanged(object sender, EventArgs args)
        {
            var selectedMake = this.Makes.SelectedItem.Text;
            var makeSelectionChangedEventArgs = new MakeSelectionChangedEventArgs(selectedMake);
            this.MakeSelectionChanged?.Invoke(null, makeSelectionChangedEventArgs);

            this.Models.DataSource = this.Model.AvailableModels;
            this.Models.DataBind();
        }

        protected void OnCreateCarFormSubmit(object sender, EventArgs args)
        {
            var selectedMake = this.Makes.SelectedItem.Text;
            var selectedModel = this.Models.SelectedItem.Text;

            var selectedOptions = new LinkedList<string>();
            foreach (ListItem item in this.Options.Items)
            {
                if (item.Selected)
                {
                    selectedOptions.AddLast(item.Text);
                }
            }

            var createCarFormSubmitEventArgs = new CreateCarFormSubmitEventArgs(selectedMake, selectedModel, selectedOptions);
            this.CreateCarFormSubmit?.Invoke(null, createCarFormSubmitEventArgs);

            this.CreatedCar.DataSource = this.Model.CreatedCar;
            this.CreatedCar.DataBind();
        }
    }
}