using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using WebFormsDataBinding.Cars.EventsArgs;
using WebFormsDataBinding.Cars.Models;
using WebFormsDataBinding.Cars.Presenters.Contracts;
using WebFormsDataBinding.Cars.ViewModels;
using WebFormsDataBinding.Cars.Views;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsDataBinding.WebClient.UserControls
{
    [PresenterBinding(typeof(ICarsPresenter))]
    public partial class CarsUserControl : MvpUserControl<CarsViewModel>, ICarsView
    {
        public event EventHandler<ChangeSelectionEventArgs> ChangeSelection;
        public event EventHandler<InitialStateEventArgs> InitialState;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var initialStateEventArgs = this.GetInitialStateEventArgs();
                this.InitialState?.Invoke(this, initialStateEventArgs);
            }
        }

        protected void OnChangeSelection(object sender, EventArgs args)
        {
            var changeSelectionEventArgs = this.GetChangeSelectionEventArgs();
            this.ChangeSelection?.Invoke(this, changeSelectionEventArgs);
        }

        private ChangeSelectionEventArgs GetChangeSelectionEventArgs()
        {
            var make = this.Makes.SelectedItem.Text;
            var options = new List<string>();
            foreach (ListItem item in this.Options.Items)
            {
                if (item.Selected)
                {
                    options.Add(item.Text);
                }
            }

            Action<IEnumerable<Car>> assignMatchingCarsDataSource = (IEnumerable<Car> matchingCars) =>
            {
                this.MatchingCars.DataSource = matchingCars;
                this.MatchingCars.DataBind();
            };

            var changeSelectionEventArgs = new ChangeSelectionEventArgs(make, options, assignMatchingCarsDataSource);

            return changeSelectionEventArgs;
        }

        private InitialStateEventArgs GetInitialStateEventArgs()
        {
            Action<IEnumerable<string>> assignMakesDataSource = (IEnumerable<string> availableMakes) =>
            {
                this.Makes.DataSource = availableMakes;
                this.Makes.DataBind();
            };

            Action<IEnumerable<string>> assignModelsDataSource = (IEnumerable<string> availableModels) =>
            {
                this.Models.DataSource = availableModels;
                this.Models.DataBind();
            };

            Action<IEnumerable<string>> assignOptionsDataSource = (IEnumerable<string> availableOptions) =>
            {
                this.Options.DataSource = availableOptions;
                this.Options.DataBind();
            };

            var initialStateEventArgs = new InitialStateEventArgs(assignMakesDataSource, assignModelsDataSource, assignOptionsDataSource);

            return initialStateEventArgs;
        }
    }
}