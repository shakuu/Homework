namespace DatabasePerformance.Data.MySql.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabasePerformance.Data.MySql.MySqlPerformanceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabasePerformance.Data.MySql.MySqlPerformanceDbContext context)
        {
            if (!context.MySqlModels.Any())
            {
                var generator = new Random();

                var modelsCount = 10000;
                for (int i = 0; i < modelsCount; i++)
                {
                    var date = this.GetRandomDate(generator);
                    var text = this.GetRandomText(generator);

                    var sqlModel = new MySqlModel()
                    {
                        Date = date,
                        Text = text
                    };

                    context.MySqlModels.Add(sqlModel);

                    if (i % 100 == 99)
                    {
                        context.SaveChanges();
                    }
                }

                context.SaveChanges();
            }
        }

        private DateTime GetRandomDate(Random generator)
        {
            var year = generator.Next(2000, 2016);
            var month = generator.Next(1, 12);
            var day = generator.Next(1, 28);

            var date = new DateTime(year, month, day);
            return date;
        }

        private string GetRandomText(Random generator)
        {
            var text = "o";
            return text;
        }
    }
}
