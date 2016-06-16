namespace StartUp._02_Test
{
    using Randomizers;
    using StudentsAndWorkers.AbstractModels;
    using StudentsAndWorkers.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
            Console.WriteLine("Problem 2. Students and workers Tasks: "
                + Environment.NewLine);

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
                var first = Generators.GenerateName(random);
                var last = Generators.GenerateName(random);
                var grade = Generators.GenerateGrade(random);
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
                var first = Generators.GenerateName(random);
                var last = Generators.GenerateName(random);
                var weekSalary = random.Next(100, 1000);
                var hoursPerDay = random.Next(4, 10);
                var worker = new Worker(first, last, weekSalary, hoursPerDay);

                output.Add(worker);
            }

            return output;
        }

        #endregion
    }
}
