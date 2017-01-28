using AutoMapper;

using WebFormsDataBinding.Employees;
using WebFormsDataBinding.Employees.Models;

namespace WebFormsDataBinding.WebClient.App_Start.AutomapperProfiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            this.CreateMap<Employee, EmployeeNames>()
                .ForMember(dto => dto.FullName, exp => exp.MapFrom(emp => emp.FirstName + " " + emp.LastName));
        }
    }
}