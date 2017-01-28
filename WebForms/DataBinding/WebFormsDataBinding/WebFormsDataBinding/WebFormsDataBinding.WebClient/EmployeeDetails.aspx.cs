using System;

using WebFormsDataBinding.Employees.EventsArgs;
using WebFormsDataBinding.Employees.Presenters.Contracts;
using WebFormsDataBinding.Employees.ViewModels;
using WebFormsDataBinding.Employees.Views;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsDataBinding.WebClient
{
    [PresenterBinding(typeof(IEmployeeDetailsPresenter))]
    public partial class EmployeeDetails : MvpPage<EmployeeDetailsViewModel>, IEmployeeDetailsView
    {
        public event EventHandler<DisplayEmployeeDetailsEventArgs> DisplayEmployeeDetails;

        protected void Page_Load(object sender, EventArgs e)
        {
            var requestedEmployeeId = this.Request.Params["id"];

            var displayEmployeeDetailsEventArgs = new DisplayEmployeeDetailsEventArgs(requestedEmployeeId);
            this.DisplayEmployeeDetails(null, displayEmployeeDetailsEventArgs);

            this.EmployeeDetailsView.DataSource = this.Model.EmployeesWithId;
            this.EmployeeDetailsView.DataBind();
        }
    }
}