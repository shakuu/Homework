
namespace Homework3.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PointAndMatrix.Lists;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string id;
        private int age;

        private GenericList<Course> courses;

        public Student(string first, string last, int age)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Age = age;

            this.courses = new GenericList<Course>();
        }

        #region Properties
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Empty string");
                }

                this.firstName = value;
            }

        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Empty string");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Age must be a positive number");
                }

                this.age = value;
            }
        }

        public string ID
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


        public int CoursesCount
        {
            get
            {
                return this.courses.Count;
            }
        }

        #endregion

        public Course GetCourseInfo(int index)
        {
            return this.courses[index];
        }

        public void AddCourseInfo(string name, int mark)
        {
            this.courses.Add(new Course(name, mark));
        }

    }
}
