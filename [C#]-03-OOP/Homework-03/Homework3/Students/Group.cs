
namespace Homework3.Students
{
    using System;
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
                if (!(0 <= value && value <= 20))
                {
                    throw new ArgumentException("Group number out of reasonable range");
                }

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

