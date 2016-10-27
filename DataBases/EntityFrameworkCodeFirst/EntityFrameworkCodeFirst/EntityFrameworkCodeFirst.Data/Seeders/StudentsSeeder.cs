using System.Collections.Generic;

using EntityFrameworkCodeFirst.Data.Seeders.Containers;
using EntityFrameworkCodeFirst.Models.SeedModels;
using EntityFrameworkCodeFirst.Models.StudentSystem;

using Newtonsoft.Json;

namespace EntityFrameworkCodeFirst.Data.Seeders
{
    public class Seeder
    {
        private readonly IJsonContainer jsonContainer;

        public Seeder(IJsonContainer jsonContainer)
        {
            this.jsonContainer = jsonContainer;
        }

        public IEnumerable<Student> SeedStudents()
        {
            var namesJson = this.jsonContainer.SeededNamesJson;
            var parsedNames = JsonConvert.DeserializeObject<List<SeedName>>(namesJson);

            var students = new LinkedList<Student>();
            foreach (var name in parsedNames)
            {
                var nextStudent = new Student()
                {
                    FirstName = name.FirstName,
                    LastName = name.LastName
                };

                students.AddLast(nextStudent);
            }

            return students;
        }

        public IEnumerable<Course> SeedCourses()
        {
            var coursesJson = this.jsonContainer.SeededCoursesJson;
            var parsedCourses = JsonConvert.DeserializeObject<List<SeedCourse>>(coursesJson);

            var courses = new LinkedList<Course>();
            foreach (var course in parsedCourses)
            {
                var nextCourse = new Course()
                {
                    Name = course.Name,
                    Description = course.Description
                };

                courses.AddLast(nextCourse);
            }

            return courses;
        }
    }
}
