using System;
using System.Linq;

using EntityFrameworkCodeFirst.Data.DbContexts;

namespace EntityFrameworkCodeFirst.ConsoleClient
{
    public class Program
    {
        public static void Main()
        {
            var dbContext = new StudentSystemDbContext();
            var students = dbContext.Students
                .Where(s => s.Courses.FirstOrDefault(c => c.Id == 2).Students.Contains(s))
                .Where(s => s.Homeworks.Any(h => h.CourseId == 2))
                .ToList();

            Console.WriteLine("Students in Course with Id: 2, who have done their homework");
            Console.WriteLine(string.Join(Environment.NewLine, students.Select(s => s.FirstName)));
        }
    }
}
