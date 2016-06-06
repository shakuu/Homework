
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
            var myStudentsGroup2 = myListOfStudents.GetStudentsFromGroup(2);
            myStudentsGroup2.SaveStudentDataToFile(nameof(myStudentsGroup2) + "csv");
        }
    }
}
