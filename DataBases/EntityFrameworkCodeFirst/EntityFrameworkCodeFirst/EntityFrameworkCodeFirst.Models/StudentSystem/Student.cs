using System.Collections.Generic;

namespace EntityFrameworkCodeFirst.Models.StudentSystem
{
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeoworks;


        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeoworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeoworks; }
            set { this.homeoworks = value; }
        }
    }
}
