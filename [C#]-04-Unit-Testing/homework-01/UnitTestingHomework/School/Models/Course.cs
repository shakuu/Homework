namespace School.Models
{
    using System;
    using System.Collections.Generic;

    using School.Contracts;
    using School.Models.Abstract;

    public class Course : BaseObject, ICourse
    {
        private int maximumCapacityInStudents;

        private ICollection<IStudent> students = new HashSet<IStudent>();

        public Course(string name, int maximumCapacityInStudents)
            : base(name)
        {
            this.maximumCapacityInStudents = maximumCapacityInStudents;
        }

        public ICollection<IStudent> Students
        {
            get
            {
                if (this.students == null)
                {
                    this.students = new HashSet<IStudent>();
                }

                return new HashSet<IStudent>(this.students);
            }

            private set
            {
                this.students = value;
            }
        }

        public bool AddStudentToCourse(IStudent student)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStudentFromCourse(IStudent student)
        {
            throw new NotImplementedException();
        }
    }
}
