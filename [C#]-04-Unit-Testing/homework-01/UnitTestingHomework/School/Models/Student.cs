namespace School.Models
{
    using System;

    using School.Contracts;
    using School.Models.Base;
    using School.Utils;

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

            set
            {
                this.id = value;
            }
        }

        public bool JoinCourse(ICourse course)
        {
            if (Validation.CheckIfObjectIsNull(course))
            {
                throw new ArgumentNullException();
            }

            course.AddStudentToCourse(this);

            return true;
        }

        public bool LeaveCourse(ICourse course)
        {
            if (Validation.CheckIfObjectIsNull(course))
            {
                throw new ArgumentNullException();
            }

            course.RemoveStudentFromCourse(this);

            return true;
        }
    }
}
