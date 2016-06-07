using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Students
{
    public class Group
    {
        private int number;
        private string department;

        public Group(int number, string department)
        {
            this.GroupNumber = number;
            this.DepartmentName = department;
        }

        #region Properties
        public int GroupNumber
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return this.department;
            }
            set
            {
                this.department = value;
            }
        }
        #endregion
    }
}

