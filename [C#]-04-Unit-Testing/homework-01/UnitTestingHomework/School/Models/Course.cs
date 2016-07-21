namespace School.Models
{
    using System;
    using System.Collections.Generic;

    using School.Contracts;
    using School.Models.Abstract;
    using School.Exceptions;
    using School.Utils;

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

        /// <summary>
        /// Validate the input, throw appropriate exception 
        /// or add the student to this course.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool AddStudentToCourse(IStudent student)
        {
            if (Validation.CheckIfObjectIsNull(student))
            {
                throw new ArgumentNullException();
            }

            if (this.students.Count == this.maximumCapacityInStudents)
            {
                throw new CourseException(CourseException.CourseOverCapacityErrorMessage);
            }

            if (this.students.Contains(student))
            {
                throw new CourseException(CourseException.DuplicateStudentErrorMessage);
            }

            this.students.Add(student);

            return true;
        }
        
        /// <summary>
        /// Should throw on Null or not existing input
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool RemoveStudentFromCourse(IStudent student)
        {
            if (Validation.CheckIfObjectIsNull(student))
            {
                throw new ArgumentNullException();
            }

            if (!this.students.Contains(student))
            {
                throw new CourseException(CourseException.StudentNotFoundErrorMessage);
            }

            this.students.Remove(student);

            return true;
        }
    }
}
