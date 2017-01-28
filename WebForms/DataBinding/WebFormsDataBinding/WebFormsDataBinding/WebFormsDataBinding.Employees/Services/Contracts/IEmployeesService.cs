using System.Collections.Generic;

using WebFormsDataBinding.Employees.Models;

namespace WebFormsDataBinding.Employees.Services.Contracts
{
    public interface IEmployeesService
    {
        IEnumerable<EmployeeNames> FindAllEmployeeNames();

        IEnumerable<Employee> FindEmployeeById(int id);
    }
}
