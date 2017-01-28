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

                this.MakesDropDownList.DataSource = this.Model.AvailableMakes;
                this.MakesDropDownList.DataBind();

                this.ModelsDropDownList.DataSource = this.Model.AvailableModels;
                this.ModelsDropDownList.DataBind();

                this.OptionsCheckBoxList.DataSource = this.Model.AvailableOptions;
                this.OptionsCheckBoxList.DataBind();
            }
        }

        protected void OnMakeSelectionChanged(object sender, EventArgs args)
        {
            var selectedMake = this.MakesDropDownList.SelectedItem.Text;
            var makeSelectionChangedEventArgs = new MakeSelectionChangedEventArgs(selectedMake);
            this.MakeSelectionChanged?.Invoke(null, makeSelectionChangedEventArgs);

            this.ModelsDropDownList.DataSource = this.Model.AvailableModels;
            this.ModelsDropDownList.DataBind();
        }

        protected void OnCreateCarFormSubmit(object sender, EventArgs args)
        {
            var selectedMake = this.MakesDropDownList.SelectedItem.Text;
            var selectedModel = this.ModelsDropDownList.SelectedItem.Text;

            var selectedOptions = new LinkedList<string>();
            foreach (ListItem item in this.OptionsCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    selectedOptions.AddLast(item.Text);
                }
            }

            var createCarFormSubmitEventArgs = new CreateCarFormSubmitEventArgs(selectedMake, selectedModel, selectedOptions);
            this.CreateCarFormSubmit?.Invoke(null, createCarFormSubmitEventArgs);

            this.CreatedCarDetailsView.DataSource = this.Model.CreatedCar;
            this.CreatedCarDetailsView.DataBind();
        }
    }
}