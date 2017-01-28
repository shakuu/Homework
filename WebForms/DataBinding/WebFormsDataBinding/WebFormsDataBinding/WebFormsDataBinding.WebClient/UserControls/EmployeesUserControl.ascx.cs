using System;

using WebFormsDataBinding.Employees.Presenters.Contracts;
using WebFormsDataBinding.Employees.ViewModels;
using WebFormsDataBinding.Employees.Views;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsDataBinding.WebClient.UserControls
{
    [PresenterBinding(typeof(IEmployeesPresenter))]
    public partial class EmployeesUserControl : MvpUserControl<EmployeesViewModel>, IEmployeesView
    {
        public event EventHandler DisplayAllEmployees;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DisplayAllEmployees?.Invoke(null, null);

            this.EmployeesGridView.DataSource = this.Model.AllEmployees;
            this.EmployeesGridView.DataBind();
        }
    }
}