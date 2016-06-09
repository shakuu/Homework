
namespace StartUp._02_Test
{
    using StudentsAndWorkers.AbstractModels;
    using StudentsAndWorkers.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Problem_02_Tests
    {

        #region Fields and Ctor
        /// <summary>
        /// Init a new Random()
        /// </summary>
        static Random random;

        static Problem_02_Tests()
        {
            random = new Random();
        }
        #endregion

        /// <summary>
        /// 1. Initialize a list of 10 students
        ///     and sort them by grade in ascending order 
        ///     (use LINQ or OrderBy() extension method).
        ///     
        /// 2. Initialize a list of 10 workers
        ///     and sort them by money per hour in descending order.
        ///     
        /// 3. Merge the lists and sort them by first name and last name.
        /// </summary>
        public static void Tasks()
        {
            const int size = 10;

            var students = GetListOfSudents(size);
            var workers = GetListOfWorkers(size);

            students =
               (from student in students
                orderby student.Grade ascending
                select student)
                .ToList();

            Print(students, "students");

            workers =
                (from worker in workers
                 orderby worker.MoneyPerHour() descending
                 select worker).ToList();

            Print(workers, "workers");

            var mergedList = new List<Human>();
            mergedList.AddRange(students.Take(students.Count));
            mergedList.AddRange(workers.Take(workers.Count));

            mergedList =
                (from human in mergedList
                 orderby human.FirstName, human.LastName
                 select human).ToList();

            Print(mergedList, "merged");
        }

        private static void Print<T>(List<T> list, string name) 
            where T : Human
        {
            Console.WriteLine($"Sorted List: {name}");
            Console.WriteLine(string.Join(
                Environment.NewLine,
                list));
            Console.WriteLine();
        }

        #region Private Methods - Generating Field Values
        
        private static List<Student> GetListOfSudents(int size)
        {
            var output = new List<Student>();

            for (int i = 0; i < size; i++)
            {
                var first = GenerateName();
                var last = GenerateName();
                var grade = GenerateGrade();
                var student = new Student(first, last, grade);
                output.Add(student);
            }

            return output;
        }

        private static List<Worker> GetListOfWorkers(int size)
        {
            var output = new List<Worker>();

            for (int i = 0; i < size; i++)
            {
                var first = GenerateName();
                var last = GenerateName();
                var weekSalary = random.Next(100, 1000);
                var hoursPerDay = random.Next(4, 10);
                var worker = new Worker(first, last, weekSalary, hoursPerDay);

                output.Add(worker);
            }

            return output;
        }
        private static string GenerateName()
        {
            const string consonants = "bcdfghjklmnpqrstvwxyz";
            const string vowels = "aeiou";

            int consonantsLength = consonants.Length;
            int vowelsLength = vowels.Length;

            var output = new StringBuilder();

            var length = random.Next(3, 8);
            var letter = 0;
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                {
                    letter = consonants[random.Next(0, consonants.Length)];
                }
                else
                {
                    letter = vowels[random.Next(0, vowels.Length)];
                }

                output.Append((char)letter);
            }

            output[0] = char.ToUpper(output[0]);

            return output.ToString();
        }

        private static double GenerateGrade()
        {
            var format = "{0}.{1}";

            var whoGrade = random.Next(2, 6);
            var decGrade = random.Next(0, 99);

            var grade = string.Format(format, whoGrade, decGrade);

            return double.Parse(grade);
        }
        #endregion
    }
}
