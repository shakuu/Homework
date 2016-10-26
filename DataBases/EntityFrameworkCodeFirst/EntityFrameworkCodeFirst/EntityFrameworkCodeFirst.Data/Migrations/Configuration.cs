using System.Data.Entity.Migrations;
using System.Linq;

using EntityFrameworkCodeFirst.Models.StudentSystem;

namespace EntityFrameworkCodeFirst.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<DbContexts.StudentSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DbContexts.StudentSystemDbContext context)
        {
            if (!context.Courses.Any())
            {
                var dataBases = new Course()
                {
                    Name = "Databases",
                    Description = "SQL Torture"
                };

                var designPatterns = new Course()
                {
                    Name = "Design Patters",
                    Description = "Programming philosophy"
                };

                context.Courses.Add(dataBases);
                context.Courses.Add(dataBases);
            }

            if (!context.Students.Any())
            {
                var studentPesho = new Student()
                {
                    Name = "Pesho"
                };

                var studentGosho = new Student()
                {
                    Name = "Gosho"
                };

                var studentStamat = new Student()
                {
                    Name = "Stamat"
                };

                context.Students.Add(studentPesho);
                context.Students.Add(studentGosho);
                context.Students.Add(studentStamat);
            }

            context.SaveChanges();
        }
    }
}
