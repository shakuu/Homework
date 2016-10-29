﻿using System;
using System.Linq;

namespace Data.Seeding.Seeders
{
    public static class StaticSeeder
    {
        private static CompanyEntities GetContext()
        {
            var context = new CompanyEntities();
            return context;
        }

        public static void SeedDepartments(int departmentsCount)
        {
            var context = StaticSeeder.GetContext();
            if (context.Departments.Any())
            {
                var count = context.Departments.Count();
                System.Console.WriteLine($"{count} departments already exist.");
                return;
            }

            for (int i = 1; i <= departmentsCount; i++)
            {
                var nextDepartmentSeed = new Department()
                {
                    Name = $"Deparment Nr.{i}"
                };

                context.Departments.Add(nextDepartmentSeed);
            }

            context.SaveChanges();
            System.Console.WriteLine("Departments successfully created.");
        }

        public static void SeedEmployees(int employeeCount)
        {
            var context = StaticSeeder.GetContext();
            if (context.Employees.Any())
            {
                var count = context.Employees.Count();
                System.Console.WriteLine($"{count} employees already in database");
                return;
            }

            var departmentsIds = context.Departments.Select(d => d.Id).ToList();
            var departmentsCount = departmentsIds.Count();

            var random = new Random();
            for (int i = 1; i <= employeeCount; i++)
            {
                var nextDepartmentIndex = random.Next(0, departmentsCount);
                var nextDepartmentId = departmentsIds[nextDepartmentIndex];

                var salary = (decimal)random.Next(50000, 200000);

                var nextSeedEmployee = new Employee()
                {
                    FirstName = $"Pesho Nr.{i}",
                    LastName = $"Peshev Nr.{i}",
                    AnnualSalary = salary,
                    DepartmentId = nextDepartmentId
                };

                context.Employees.Add(nextSeedEmployee);
            }



            context.SaveChanges();
        }
    }
}
