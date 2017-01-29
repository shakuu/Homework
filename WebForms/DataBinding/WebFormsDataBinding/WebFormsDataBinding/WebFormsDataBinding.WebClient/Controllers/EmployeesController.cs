using System.Linq;
using System.Web.Http;

using Ninject;

using WebFormsDataBinding.Employees.Services.Contracts;
using WebFormsDataBinding.WebClient.App_Start;

namespace WebFormsDataBinding.WebClient.Controllers
{
    public class EmployeesController : ApiController
    {
        public EmployeesController()
        {
            NinjectWebCommon.NinjectKernel.Inject(this);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = this.EmployeesService.FindEmployeeById(id).FirstOrDefault();

            if (employee != null)
            {
                var response = new
                {
                    Title = employee.Title,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    City = employee.City,
                };

                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [Inject]
        public IEmployeesService EmployeesService { get; set; }
    }
}
