
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
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public int CoursesCouhjt
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
