using System.Collections.Generic;

using WebFormsDataBinding.Employees.Models;

namespace WebFormsDataBinding.Employees.ViewModels
{
    public class EmployeesViewModel
    {
        public IEnumerable<EmployeeNames> AllEmployees { get; set; }
    }
}
