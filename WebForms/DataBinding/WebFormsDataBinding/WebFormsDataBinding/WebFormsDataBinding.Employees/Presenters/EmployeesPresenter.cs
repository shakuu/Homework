using System;

using WebFormsDataBinding.Employees.Presenters.Contracts;
using WebFormsDataBinding.Employees.Services.Contracts;
using WebFormsDataBinding.Employees.Views;

using WebFormsMvp;

namespace WebFormsDataBinding.Employees.Presenters
{
    public class EmployeesPresenter : Presenter<IEmployeesView>, IEmployeesPresenter
    {
        private readonly IEmployeesView view;
        private readonly IEmployeesService employeesService;

        public EmployeesPresenter(IEmployeesView view, IEmployeesService employeesService)
            : base(view)
        {
            this.view = view;
            this.view.DisplayAllEmployees += this.OnDisplayAllEmployees;

            this.employeesService = employeesService;
        }

        private void OnDisplayAllEmployees(object sender, EventArgs args)
        {
            this.view.Model.AllEmployees = this.employeesService.FindAllEmployeeNames();
        }
    }
}
