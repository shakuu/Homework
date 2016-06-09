
namespace SchoolClasses.People
{
    using System;
    using Interfaces;
    using Validation.ValidateStrings;
    using System.Collections.Generic;
    using System.Linq;

    public class SchoolClass : ICommentable
    {
        private string id;
        private string comment;
        private List<Teacher> teachers;
        private List<Student> students;

        public SchoolClass()
        {
            this.teachers = new List<Teacher>();
            this.students = new List<Student>();

        }

        public SchoolClass(string id)
            : this()
        {
            this.ID = id;
        }

        #region Properties
        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                ValidateString.ValidateComment(value);
                this.comment = value;
            }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                ValidateString.ValidateClassID(value);
                this.id = value; 
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
            set
            {
                this.teachers = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
            private set
            {
                this.students = value;
            }
        }
        #endregion

        public void AddStudent(Student student)
        {
            var check = this.students.Where(std => std.ClassNumber == student.ClassNumber).Count();

            if (check > 0)
            {
                throw new ArgumentException("Student Class Numbers must be unique for the class");
            }
            else
            {
                this.Students.Add(student);
            }
        }
    }
}
