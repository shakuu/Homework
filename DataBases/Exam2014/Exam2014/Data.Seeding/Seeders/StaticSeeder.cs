using System;
using System.Collections.Generic;
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
                System.Console.WriteLine($"{count} employees already exist");
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

                if (i % 50 == 0)
                {
                    context.SaveChanges();
                    context = StaticSeeder.GetContext();
                }
            }

            context.SaveChanges();
            System.Console.WriteLine("Emplyees successfully created.");

            StaticSeeder.CreateManagers();
        }

        private static void CreateManagers()
        {
            var context = StaticSeeder.GetContext();
            if (!context.Employees.Any())
            {
                Console.WriteLine("No employees found");
                return;
            }

            var allEmployees = context.Employees.ToList();
            var employeesCount = allEmployees.Count;
            var managersCount = (int)Math.Ceiling(employeesCount * 0.05);

            var employeesPerManager = employeesCount / managersCount;
            var firstEmployeeIndex = managersCount;

            for (int manager = 0; manager < managersCount; manager++)
            {
                var managerId = allEmployees[manager].Id;

                for (int employee = firstEmployeeIndex; employee < firstEmployeeIndex + employeesPerManager; employee++)
                {
                    if (employeesCount <= employee)
                    {
                        break;
                    }

                    allEmployees[employee].ManagerId = managerId;
                }

                firstEmployeeIndex += employeesPerManager;
            }

            context.SaveChanges();
        }

        /// <summary>
        /// 1 000 projects – on each project there are working between 2 and 20 employees, 
        /// inclusive – average of 5. Ending date is always after starting date (you don’t say) 
        /// and ending date may be in the future.
        /// </summary>
        /// <param name="projectsCount"></param>
        public static void SeedProjects(int projectsCount)
        {
            var context = StaticSeeder.GetContext();
            if (context.Projects.Any())
            {
                var count = context.Projects.Count();
                Console.WriteLine($"{count} projects already exits.");
                return;
            }

            var random = new Random();
            var allEmployeesIds = context.Employees.Select(e => e.Id).ToList();
            for (int i = 0; i < projectsCount; i++)
            {
                var project = new Project()
                {
                    Name = $"New Project Nr. {i}"
                };

                var endYear = random.Next(2012, 2022);
                var startYear = random.Next(endYear - 10, endYear);

                var startDate = new DateTime(startYear, 1, 1);
                var endDate = new DateTime(endYear, 1, 1);

                var picked = new List<int>();
                var employeesCount = random.Next(2, 20);
                for (int k = 0; k < employeesCount; k++)
                {
                    var nextEmployeeId = random.Next(0, allEmployeesIds.Count);
                    while (picked.Contains(nextEmployeeId))
                    {
                        nextEmployeeId = random.Next(0, allEmployeesIds.Count);
                    }

                    picked.Add(nextEmployeeId);
                    var nextEmployee = allEmployeesIds[nextEmployeeId];

                    var employeeProject = new Employees_Projects()
                    {
                        EmployeeId = nextEmployee,
                        StartDate = startDate,
                        EndDate = endDate
                    };

                    project.Employees_Projects.Add(employeeProject);
                }

                context.Projects.Add(project);
                if (i % 50 == 0)
                {
                    context.SaveChanges();
                    context = StaticSeeder.GetContext();
                }
            }

            context.SaveChanges();
        }
    }
}
