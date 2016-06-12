﻿namespace StartUp._01_StudentAssembly_Tests
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
    }
}