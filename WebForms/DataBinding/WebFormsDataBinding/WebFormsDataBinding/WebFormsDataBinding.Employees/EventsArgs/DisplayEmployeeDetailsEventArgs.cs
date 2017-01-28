using System;

namespace WebFormsDataBinding.Employees.EventsArgs
{
    public class DisplayEmployeeDetailsEventArgs : EventArgs
    {
        public DisplayEmployeeDetailsEventArgs(string employeeId)
        {
            this.EmployeeId = employeeId;
        }

        public string EmployeeId { get; set; }
    }
}
