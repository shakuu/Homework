using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsDataBinding.Employees.Views;
using WebFormsMvp;

namespace WebFormsDataBinding.Employees.Presenters
{
    public class EmployeesPresenter : Presenter<IEmployeesView>
    {
        public EmployeesPresenter(IEmployeesView view)
            : base(view)
        {
        }
    }
}
