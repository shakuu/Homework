using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Index(IsClustered = false, IsUnique = true)]
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
