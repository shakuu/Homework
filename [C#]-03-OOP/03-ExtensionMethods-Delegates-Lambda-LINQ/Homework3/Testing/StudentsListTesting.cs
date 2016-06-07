
namespace Homework3.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Students;
    using Extensions;

    public static class StudentsListTesting
    {
        public static void MainTest()
        {
            var myListOfStudents = new List<Student>();

            myListOfStudents.LoadStudentDataFromFile("Students.csv");
            var myStudentsGroup2 = myListOfStudents.GetStudentsByGroup(2);
            myStudentsGroup2.SaveStudentDataToFile(nameof(myStudentsGroup2) + "csv");

            myListOfStudents.GetStudentsByMarks(6);


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

            output.Add(new Group(1, "Mathematics"));
            output.Add(new Group(2, "Economics"));
            output.Add(new Group(3, "History"));
            output.Add(new Group(4, "Law"));

            return output;
        }
    }
}
