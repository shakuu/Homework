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
                .ForMember(destination => destination.FullName, options => options.MapFrom(source => source.FirstName + " " + source.LastName))
                .ForMember(destination => destination.Id, options => options.MapFrom(source => source.EmployeeID));
        }
    }
}