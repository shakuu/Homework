namespace Homework3
{
    using System;
    using Testing;

    class StartUp
    {
        static Random rng = new Random();

        /// <summary>
        /// See Readme.txt for Student data input instructions 
        /// ( copy Students.csv to /bin/Debug )
        /// Substring extensions   : Extensions -> StringBuilderExtensions.cs
        /// IEnumerable extensions : Extensions -> IEnumerableExtensions.cs
        /// Problems with Student  : Extensions -> StudenListExtensions.cs
        /// Timed even is tested through a "for testing" constructor of class Student, see Testing -> TimerTesting.cs
        /// </summary>
        static void Main()
        {
            StudentsListTesting.GroupsTesting();
            //StudentsListTesting.MainTest();
        }
    }
}
