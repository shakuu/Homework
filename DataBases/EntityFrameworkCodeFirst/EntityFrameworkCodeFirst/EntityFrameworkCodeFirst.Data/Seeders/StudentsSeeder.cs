using System.Collections.Generic;

using EntityFrameworkCodeFirst.Data.Seeders.Containers;
using EntityFrameworkCodeFirst.Models.StudentSystem;

using Newtonsoft.Json;

namespace EntityFrameworkCodeFirst.Data.Seeders
{
    public class StudentsSeeder
    {
        private readonly IJsonContainer jsonContainer;

        public StudentsSeeder(IJsonContainer jsonContainer)
        {
            this.jsonContainer = jsonContainer;
        }

        public IEnumerable<Student> SeedStudents(int number)
        {
            var namesJson = this.jsonContainer.SeededNamesJson;
            var parsedNames = JsonConvert
            
        }
    }
}
