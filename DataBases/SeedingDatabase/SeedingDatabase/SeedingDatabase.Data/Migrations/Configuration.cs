using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using SeedingDatabase.Models.Courses;
using SeedingDatabase.Models.Names;

namespace SeedingDatabase.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SeedingData.SeedingDataDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SeedingData.SeedingDataDbContext context)
        {
            if (!context.Names.Any())
            {
                var json = File.ReadAllText("D:\\GitHub\\SeedingJson\\names.json");
                var items = JsonConvert.DeserializeObject<List<Name>>(json);

                foreach (var item in items)
                {
                    context.Names.Add(item);
                }
            }

            if (!context.Courses.Any())
            {
                var json = File.ReadAllText("D:\\GitHub\\SeedingJson\\courses.json");
                var items = JsonConvert.DeserializeObject<List<Course>>(json);

                foreach (var item in items)
                {
                    context.Courses.Add(item);
                }
            }

            context.SaveChanges();
        }
    }
}
