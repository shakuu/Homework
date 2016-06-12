namespace StartUp._01_StudentAssembly_Tests
{
    using StudentAssembly.Types;
    using System;

    public static class BasicTests
    {
        public static void TestEquals()
        {
            var test = new StudentAssembly.Models.Student
            {
                FirstName = "a",
                MiddleName = "b",
            };

            var test1 = new StudentAssembly.Models.Student
            {
                FirstName = "a",
                MiddleName = "b"
            };

            Console.WriteLine(test.ToString());
            Console.WriteLine(test1.ToString());

            Console.WriteLine(test.Equals(test1));
        }

        public static void TestHash()
        {
            var test = new StudentAssembly.Models.Student
            {
                FirstName = "a",
                MiddleName = "b",
                LastName = "mahalalov",
                Email = "blah@mlah.glah",
                Faculty = FacultyType.Law
            };

            var test1 = new StudentAssembly.Models.Student
            {
                FirstName = "a",
                MiddleName = "b",
                Faculty = FacultyType.Law
            };

            Console.WriteLine(test.Equals(test1));
            Console.WriteLine(test.GetHashCode());
            Console.WriteLine(test1.GetHashCode());
        }

        public static void TestClone()
        {
            var test = new StudentAssembly.Models.Student
            {
                FirstName = "a",
                MiddleName = "b",
                LastName = "mahalalov",
                Email = "blah@mlah.glah",
                Faculty = FacultyType.Law
            };

            var test1 = (StudentAssembly.Models.Student) test.Clone();


            Console.WriteLine(test.ToString());
            Console.WriteLine(test1.ToString());
            Console.WriteLine(test.Equals(test1));
            Console.WriteLine(test.GetHashCode());
            Console.WriteLine(test1.GetHashCode());
        }
    }
}
