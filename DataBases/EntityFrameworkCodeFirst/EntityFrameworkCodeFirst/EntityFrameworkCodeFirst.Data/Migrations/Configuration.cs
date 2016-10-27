using System.Data.Entity.Migrations;
using System.Linq;

using EntityFrameworkCodeFirst.Data.Seeders;
using EntityFrameworkCodeFirst.Data.Seeders.Containers;
using System;

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
            var coursesExist = context.Courses.Any();
            var studentsExist = context.Students.Any();
            if (!(coursesExist && studentsExist))
            {
                var jsonContainer = new JsonContainer();
                var seeder = new Seeder(jsonContainer);

                var students = seeder.SeedStudents();
                foreach (var student in students)
                {
                    context.Students.Add(student);
                }

                var random = new Random();
                var studentsCount = students.Count;
                var studentsPerCourse = 20;

                var courses = seeder.SeedCourses();
                foreach (var course in courses)
                {
                    for (int i = 0; i < studentsPerCourse; i++)
                    {
                        var nextStudentId = random.Next(0, studentsCount);
                        var nextStudent = students[nextStudentId];

                        course.Students.Add(nextStudent);
                        nextStudent.Courses.Add(course);
                    }

                    context.Courses.Add(course);
                }
            }

            context.SaveChanges();
        }
    }
}
