using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using WebFormsDataBinding.Employees.Models;
using WebFormsDataBinding.Employees.Services.Contracts;

namespace WebFormsDataBinding.Employees.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly NorthwindEntities dbContext;

        public EmployeesService(NorthwindEntities dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<EmployeeNames> FindAllEmployeeNames()
        {
            return this.dbContext.Employees.ProjectToList<EmployeeNames>();
        }

        public IEnumerable<Employee> FindEmployeeById(int id)
        {
            return this.dbContext.Employees.Where(emp => emp.EmployeeID == id).ToList();
        }
    }
}
