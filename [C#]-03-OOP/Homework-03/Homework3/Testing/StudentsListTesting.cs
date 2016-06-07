
namespace Homework3.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Students;
    using Extensions;
    using Enumerators;

    public static class StudentsListTesting
    {
        public static void MainTest()
        {
            var myListOfStudents = new List<Student>();

            myListOfStudents.LoadStudentDataFromFile("Students.csv");
            var myStudentsGroup2 = myListOfStudents.GetStudentsByGroup(2);
            myStudentsGroup2.SaveStudentDataToFile(nameof(myStudentsGroup2) + "csv");

            myListOfStudents.GetStudentsByMarks(6);



            Console.WriteLine(string.Join(Environment.NewLine, myListOfStudents));


        }

        public static void GroupsTesting()
        {
            var myListOfStudents = new List<Student>();
            var myGroups = CreateGroups();

            myListOfStudents.LoadStudentDataFromFile("Students.csv");

            var marks = myListOfStudents.GetMarksOfStudentsByYear("06");
            foreach (var item in marks)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }

        public static void CreateNewList(Random rng)
        {
            // Modify list

            // Replace FN
            //myListOfStudents.ModfiyFN(rng);
            //myListOfStudents.SaveStudentDataToFile("Students2.csv");

        }

        private static List<Group> CreateGroups()
        {
            var output = new List<Group>();

            output.Add(new Group(1, DepartmentsType.Mathematics));
            output.Add(new Group(2, DepartmentsType.Economics));
            output.Add(new Group(3, DepartmentsType.History));
            output.Add(new Group(4, DepartmentsType.Law));

            return output;
        }
    }
}
