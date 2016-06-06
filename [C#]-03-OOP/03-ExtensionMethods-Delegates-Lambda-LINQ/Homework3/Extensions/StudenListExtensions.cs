

namespace Homework3.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Students;
    using System.IO;

    public static class StudenListExtensions
    {
        public static void LoadStudentDataFromFile(this List<Student> list, string filename)
        {
            try
            {
                using (var reader = new StreamReader(filename, Encoding.UTF8))
                {
                    // First Line headers
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var data = reader.ReadLine()
                            .Trim()
                            .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

                        // FirstName|LastName|FN|Phone|Email|Group|Marks|Marks|Marks|Marks
                        var newStudent = new Student()
                        {
                            FirstName = data[0],
                            LastName = data[1],
                            FN = int.Parse(data[2]),
                            Tel = data[3],
                            Email = data[4],
                            Group = int.Parse(data[5]),
                        };

                        // Add All Marks
                        for (int index = 6; index < data.Length; index++)
                        {
                            newStudent.Marks.Add(int.Parse(data[index]));
                        }

                        list.Add(newStudent);
                    }

                    reader.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static void SaveStudentDataToFile(this List<Student> list, string filename)
        {
            var header = "FirstName|LastName|FN|Phone|Email|Group|Marks|Marks|Marks|Marks";

            using (var writer = new StreamWriter(filename, false, Encoding.UTF8))
            {
                writer.WriteLine(header);

                foreach (var student in list)
                {
                    writer.WriteLine(student.ToString());
                }

                writer.Close();
            }
        }

        public static void OrderByStudentFirstName(this List<Student> list)
        {
            list =
                (from student in list
                 orderby student.FirstName
                 select student)
                 .ToList();
        }
        public static void OrderByStudentFirstNameLINQ(this List<Student> list)
        {
            list = list.OrderBy(student => student.FirstName).ToList();
        }

        public static List<Student> GetStudentsByGroup(this List<Student> list, int group)
        {
            var output =
                from student in list
                where student.Group == 2
                select student;

            return output.ToList();
        }
        public static List<Student> GetStudentsByEmail(this List<Student> list, string domain)
        {
            Func<string, bool> Check = (input) =>
            {
                var studentDomain = input.Split('@').ToArray()[1];
                return studentDomain == domain;
            };

            var output = list
                .Where(student => Check(student.Email))
                .ToList();

            return output;
        }
        public static List<Student> GetStudentsByTel(this List<Student> list, string areaCode)
        {
            // Assuming (062) 92037385
            Func<string, bool> Check = (input) =>
            {
                var studentAreaCode = input
                    .Split(new[] { '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray()[0];

                return studentAreaCode == areaCode;
            };

            var output = list
                .Where(student => Check(student.Tel))
                .ToList();

            return output;
        }
        public static dynamic GetStudentsByMarks(this List<Student> list, int mark)
        {
            var output =
                from student in list
                where student.Marks.Any(m => m == mark)
                select new
                {
                    FullName = student.FirstName + " " + student.LastName,
                    Marks = string.Join(", ", student.Marks)
                };

            // Testing
            //Console.WriteLine(string.Join(Environment.NewLine, output));

            return output;
        }
        public static List<Student> GetStudentsByTwoMarks(this List<Student> list, int mark, int occurnaces)
        {
            Func<List<int>, bool> Check = (studentMarks) => 
                studentMarks.Where(m => m == mark).Count() == occurnaces;
            
            var output = list
                .Where(student => Check(student.Marks))
                .ToList();

            return output;
        }
    }
}
