using System;

using WebFormsDataBinding.Employees.ViewModels;

using WebFormsMvp;

namespace WebFormsDataBinding.Employees.Views
{
    public interface IEmployeesView : IView<EmployeesViewModel>
    {
        event EventHandler DisplayAllEmployees;
    }
}
