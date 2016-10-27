using System;
using System.Linq;

using EntityFrameworkCodeFirst.Data.DbContexts;

namespace EntityFrameworkCodeFirst.ConsoleClient
{
    public class Startup
    {
        /// <summary>
        /// Open package manager console and paste the following
        /// Update-Database -TargetMigration: "init" -Verbose
        /// Note: pmc autocomplete works with TAB 
        /// You can access the created db in ssms through 
        /// (localdb)\mssqllocaldb 
        /// </summary>
        public static void Main()
        {
            var context = new StudentSystemDbContext();
            var students = context.Students
                .Where(s => s.Courses.FirstOrDefault(c => c.Id == 2).Students.Contains(s))
                .Where(s => s.Homeworks.Any(h => h.CourseId == 2))
                .ToList();

            Console.WriteLine("Students in Course with Id: 2, who have done their homework");
            Console.WriteLine(string.Join(Environment.NewLine, students.Select(s => s.FirstName)));
        }
    }
}
