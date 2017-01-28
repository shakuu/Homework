using System.Collections.Generic;

using WebFormsDataBinding.Employees.EventsArgs;
using WebFormsDataBinding.Employees.Presenters.Contracts;
using WebFormsDataBinding.Employees.Services.Contracts;
using WebFormsDataBinding.Employees.Views;

using WebFormsMvp;

namespace WebFormsDataBinding.Employees.Presenters
{
    public class EmployeeDetailsPresenter : Presenter<IEmployeeDetailsView>, IEmployeeDetailsPresenter
    {
        private readonly IEmployeeDetailsView view;
        private readonly IEmployeesService employeesService;

        public EmployeeDetailsPresenter(IEmployeeDetailsView view, IEmployeesService employeesService)
            : base(view)
        {
            this.view = view;
            this.view.DisplayEmployeeDetails += this.OnDisplayEmployeeDetails;

            this.employeesService = employeesService;
        }

        private void OnDisplayEmployeeDetails(object sender, DisplayEmployeeDetailsEventArgs args)
        {
            int employeeId;
            var isParsed = int.TryParse(args.EmployeeId, out employeeId);
            if (isParsed)
            {
                this.view.Model.EmployeesWithId = this.employeesService.FindEmployeeById(employeeId);
            }
            else
            {
                this.view.Model.EmployeesWithId = new List<Employee>();
            }
        }
    }
}
