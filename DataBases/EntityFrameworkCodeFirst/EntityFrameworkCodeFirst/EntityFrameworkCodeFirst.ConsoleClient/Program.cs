using EntityFrameworkCodeFirst.Data.Seeders;
using EntityFrameworkCodeFirst.Data.Seeders.Containers;

namespace EntityFrameworkCodeFirst.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var jsonContainer = new JsonContainer();
            var seeder = new Seeder(jsonContainer);

            var hw = seeder.SeedHomework();
        }
    }
}
