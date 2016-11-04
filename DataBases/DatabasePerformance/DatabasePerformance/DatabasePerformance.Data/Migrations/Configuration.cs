namespace DatabasePerformance.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PerformanceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PerformanceDbContext context)
        {
            var modelsWithIndexExists = context.ModelsWithIndex.Any();
            var modelsWithoutIndexExists = context.ModelsWithoutIndex.Any();

            if (!(modelsWithIndexExists && modelsWithoutIndexExists))
            {
                var generator = new Random();

                // 10 mil takes forever and ever and ever.
                var modelsCount = 10000;
                for (int i = 0; i < modelsCount; i++)
                {
                    var date = this.GetRandomDate(generator);
                    var text = this.GetRandomText(generator);

                    var withIndex = new ModelWithIndex()
                    {
                        Date = date,
                        Text = text
                    };

                    var withoutIndex = new ModelWithoutIndex()
                    {
                        Date = date,
                        Text = text
                    };

                    var withTwoIndexes = new ModelWithTwoIndexes()
                    {
                        Date = date,
                        Text = text
                    };

                    context.ModelsWithIndex.Add(withIndex);
                    context.ModelsWithoutIndex.Add(withoutIndex);
                    context.ModelsWithTwoIndexes.Add(withTwoIndexes);

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
