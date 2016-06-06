
namespace Homework3.Students
{
    using System;
    using System.Linq;
    using System.Text;
    using PointAndMatrix.Lists;
    using System.IO;
    using System.Collections;
    using Extensions;

    public class ClassOfStudents : IEnumerable
    {
        private GenericList<Student> students;

        public ClassOfStudents()
        {
            students = new GenericList<Student>();
        }

        #region Homework Methods
        public ClassOfStudents FirstBeforeLast()
        {
            var output =
                from Student student in this.students
                where string.Compare(student.FirstName, student.LastName) < 1
                select student;

            return output.ToClassOfStudents();
        }

        public ClassOfStudents AgeRange(int min, int max)
        {
            var outputNamesStrings =
                from Student student in this.students
                where 18 <= student.Age && student.Age <= 24
                select student.FirstName + student.LastName;

            var outputToClassOfStudents =
                from Student student in this.students
                where 18 <= student.Age && student.Age <= 24
                select student;
            
            return outputToClassOfStudents.ToClassOfStudents();
        }

        public ClassOfStudents OrderByLambda()
        {
            var output =
                 from Student student in this.students
                 orderby student.FirstName, student.LastName
                 select student;

            return output.ToClassOfStudents();
        }
        #endregion

        #region Methods
        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void AddStudent(string first, string last)
        {
            this.students.Add(new Student(first, last));
        }
        public void RemoveStudent(int index)
        {
            this.students.Remove(index);
        }
        public void SaveToFile(string filename)
        {
            var toWrite = new StringBuilder();

            using (var writer = new StreamWriter(filename))
            {
                foreach (Student student in this.students)
                {
                    toWrite.AppendFormat("{0} {1} {2}",
                        student.FirstName,
                        student.LastName,
                        student.Age);

                    writer.WriteLine(toWrite);

                    toWrite.Clear();
                }
            }
        }
        
        #endregion

        #region Static Methods
        public static ClassOfStudents CreateFromFile(string filename)
        {
            var output = new ClassOfStudents();

            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var studentInfo = reader.ReadLine()
                        .Trim()
                        .Split(new[] { ' ' , '�' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var newStudent = new Student(
                        studentInfo[0],
                        studentInfo[1]);

                    output.AddStudent(newStudent);
                }
                
            }

            return output;
        }

        #endregion

        #region Interface implementations
        public IEnumerator GetEnumerator()
        {
            return this.students.GetEnumerator();
        }
        #endregion
    }
}
