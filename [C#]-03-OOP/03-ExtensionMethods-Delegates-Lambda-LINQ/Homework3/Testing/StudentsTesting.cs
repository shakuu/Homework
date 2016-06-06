
namespace Homework3.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Students;

    public static class StudentsTesting
    {
        public static void MainTest(Random rng)
        {
            // Create a ClassOfStudents
            var filename = @"myClassOfStudents.txt";
            var myClassOfStudents = ClassOfStudents.CreateFromFile(filename);
        }
    }
}
