using System;

using WebFormsDataBinding.Employees.EventsArgs;
using WebFormsDataBinding.Employees.ViewModels;

using WebFormsMvp;

namespace WebFormsDataBinding.Employees.Views
{
    public interface IEmployeeDetailsView : IView<EmployeeDetailsViewModel>
    {
        event EventHandler<DisplayEmployeeDetailsEventArgs> DisplayEmployeeDetails;
    }
}
