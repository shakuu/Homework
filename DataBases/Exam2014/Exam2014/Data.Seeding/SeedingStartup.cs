using Data.Seeding.Seeders;

namespace Data.Seeding
{
    public class SeedingStartup
    {
        public static void Main()
        {
            StaticSeeder.SeedDepartments(101);
            StaticSeeder.SeedEmployees(5001);
            StaticSeeder.SeedProjects(1001);
        }
    }
}
