namespace School.Models
{
    using System;
    using School.Contracts;
    using School.Models.Base;

    public class Student : BaseNameableObject, IStudent
    {
        private int id;

        public Student(string name, int id)
            : base(name)
        {
        }

        public int ID
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.id = value;
            }
        }

        public bool JoinCourse(ICourse course)
        {
            throw new NotImplementedException();
        }

        public bool LeaveCourse(ICourse course)
        {
            throw new NotImplementedException();
        }
    }
}
