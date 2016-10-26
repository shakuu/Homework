using System.Data.Entity;

using EntityFrameworkCodeFirst.Models.StudentSystem;

namespace EntityFrameworkCodeFirst.Data.DbContexts
{
    public class StudentSystemDbContext : DbContext
    {
        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public virtual IDbSet<CourseMaterial> CourseMaterials { get; set; }
    }
}
