namespace School.Models
{
    using System;
    using School.Contracts;
    using School.Models.Abstract;

    public class Student : BaseObject, IStudent
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
