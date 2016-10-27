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

        public IEnumerable<Student> SeedStudents(int number)
        {
            var namesJson = this.jsonContainer.SeededNamesJson;
            var parsedNames = JsonConvert.DeserializeObject<List<SeedName>>(namesJson);

            var students = new LinkedList<Student>();
            for (int i = 0; i < number; i++)
            {
                var name = parsedNames[i];
                var nextStudent = new Student()
                {
                    FirstName = name.FirstName,
                    LastName = name.LastName
                };
            }

            return students;
        }
    }
}
