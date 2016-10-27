using System.Collections.Generic;

using EntityFrameworkCodeFirst.Data.Seeders.Containers;
using EntityFrameworkCodeFirst.Models.SeedModels;
using EntityFrameworkCodeFirst.Models.StudentSystem;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EntityFrameworkCodeFirst.Data.Seeders
{
    public class Seeder
    {
        private readonly IJsonContainer jsonContainer;

        public Seeder(IJsonContainer jsonContainer)
        {
            this.jsonContainer = jsonContainer;
        }

        public IList<Student> SeedStudents()
        {
            var namesJson = this.jsonContainer.SeededNamesJson;
            var parsedNames = JsonConvert.DeserializeObject<List<SeedName>>(namesJson);

            var students = new List<Student>();
            foreach (var name in parsedNames)
            {
                var nextStudent = new Student()
                {
                    FirstName = name.FirstName,
                    LastName = name.LastName,
                    StudentNumber = name.StudentNumber
                };

                students.Add(nextStudent);
            }

            return students;
        }

        public IList<Course> SeedCourses()
        {
            var coursesJson = this.jsonContainer.SeededCoursesJson;
            var parsedCourses = JsonConvert.DeserializeObject<List<SeedCourse>>(coursesJson);

            var courses = new List<Course>();
            foreach (var course in parsedCourses)
            {
                var nextCourse = new Course()
                {
                    Name = course.Name,
                    Description = course.Description
                };

                courses.Add(nextCourse);
            }

            return courses;
        }

        public IList<Homework> SeedHomework()
        {
            var coursesJson = this.jsonContainer.SeededHomeworksJson;
            var parsedCourses = JsonConvert.DeserializeObject<List<SeedHomework>>(coursesJson, new IsoDateTimeConverter { DateTimeFormat = "MM/dd/yyyy" });

            var courses = new List<Homework>();
            foreach (var course in parsedCourses)
            {
                var nextCourse = new Homework()
                {
                    Content = course.Content,
                    TimeSent = course.TimeSent
                };

                courses.Add(nextCourse);
            }

            return courses;
        }
    }
}
