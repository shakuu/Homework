using System.Collections.Generic;

namespace EntityFrameworkCodeFirst.Models.StudentSystem
{
    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Homework> homeoworks;
        private ICollection<CourseMaterial> courseMaterials;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeoworks = new HashSet<Homework>();
            this.courseMaterials = new HashSet<CourseMaterial>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeoworks; }
            set { this.homeoworks = value; }
        }

        public virtual ICollection<CourseMaterial> CourseMaterials
        {
            get { return this.courseMaterials; }
            set { this.courseMaterials = value; }
        }
    }
}
