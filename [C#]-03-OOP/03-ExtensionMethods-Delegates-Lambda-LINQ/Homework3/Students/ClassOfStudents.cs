
namespace Homework3.Students
{
    using System;
    using System.Linq;
    using System.Text;
    using PointAndMatrix.Lists;
    using System.IO;
    using System.Collections;

    public class ClassOfStudents : IEnumerable
    {
        private GenericList<Student> students;

        public ClassOfStudents()
        {
            students = new GenericList<Student>();
        }

        #region Methods
        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void AddStudent(string first, string last, int age)
        {
            this.students.Add(new Student(first, last, age));
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

        public IEnumerator GetEnumerator()
        {
            return this.students.GetEnumerator();
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
                        studentInfo[1],
                        int.Parse(studentInfo[2]));

                    output.AddStudent(newStudent);
                }
                
            }

            return output;
        }

        #endregion
    }
}
