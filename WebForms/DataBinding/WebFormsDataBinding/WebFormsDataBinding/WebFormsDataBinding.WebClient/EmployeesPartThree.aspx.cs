using System;

using WebFormsDataBinding.Employees.Presenters.Contracts;
using WebFormsDataBinding.Employees.ViewModels;
using WebFormsDataBinding.Employees.Views;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsDataBinding.WebClient
{
    [PresenterBinding(typeof(IEmployeesPresenter))]
    public partial class EmployeesPartThree : MvpPage<EmployeesViewModel>, IEmployeesView
    {
        public event EventHandler DisplayAllEmployees;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DisplayAllEmployees(null, null);

            this.Employees.DataSource = this.Model.AllEmployees;
            this.Employees.DataBind();
        }
    }
}