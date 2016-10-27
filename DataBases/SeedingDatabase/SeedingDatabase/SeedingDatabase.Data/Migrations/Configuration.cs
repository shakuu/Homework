using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

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
                var json = File.ReadAllText("D:\\GitHub\\names.json");
                var items = JsonConvert.DeserializeObject<List<Name>>(json);

                foreach (var item in items)
                {
                    context.Names.Add(item);
                }

                context.SaveChanges();
            }
        }
    }
}
