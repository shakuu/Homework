﻿using Data.Seeding.Seeders;

namespace Data.Seeding
{
    public class SeedingStartup
    {
        public static void Main()
        {
            StaticSeeder.SeedDepartments(101);
        }
    }
}
