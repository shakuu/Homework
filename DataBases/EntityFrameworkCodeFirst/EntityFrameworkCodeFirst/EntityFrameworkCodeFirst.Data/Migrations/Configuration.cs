using System;
using System.Data.Entity.Migrations;
using System.Linq;

using EntityFrameworkCodeFirst.Data.Seeders;
using EntityFrameworkCodeFirst.Data.Seeders.Containers;
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
            var coursesExist = context.Courses.Any();
            var studentsExist = context.Students.Any();
            var homeworksExist = context.Homeworks.Any();
            if (!(coursesExist && studentsExist && homeworksExist))
            {
                var jsonContainer = new JsonContainer();
                var seeder = new Seeder(jsonContainer);

                var students = seeder.SeedStudents();

                var homeworks = seeder.SeedHomework();

                var studentNumber = 1000000001;
                var random = new Random();
                var homeworkCount = homeworks.Count;
                var studentsCount = students.Count;
                var studentsPerCourse = 20;

                var courses = seeder.SeedCourses();
                foreach (var course in courses)
                {
                    for (int i = 0; i < studentsPerCourse; i++)
                    {
                        var nextStudentId = random.Next(0, studentsCount);
                        var nextStudent = new Student()
                        {
                            FirstName = students[nextStudentId].FirstName,
                            LastName = students[nextStudentId].LastName,
                            StudentNumber = studentNumber.ToString().PadLeft(10)
                        };

                        studentNumber++;

                        course.Students.Add(nextStudent);
                        nextStudent.Courses.Add(course);

                        var nextHomeworkId = random.Next(0, homeworkCount);
                        var nextHomework = new Homework()
                        {
                            Content = homeworks[nextHomeworkId].Content,
                            TimeSent = homeworks[nextHomeworkId].TimeSent,
                        };

                        nextHomework.Student = nextStudent;
                        nextHomework.Course = course;
                        context.Homeworks.Add(nextHomework);
                    }

                    context.Courses.Add(course);
                }
            }

            context.SaveChanges();
        }
    }
}
