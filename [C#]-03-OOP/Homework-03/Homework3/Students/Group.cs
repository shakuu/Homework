
namespace Homework3.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Enumerators;

    public class Group
    {
        private int number;
        private DepartmentsType department;

        public Group(int number, DepartmentsType department)
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

        public DepartmentsType DepartmentName
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

