namespace Homework3.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Students;
    using System.IO;
    using Enumerators;

    public static class StudenListExtensions
    {
        #region Homework Problems
        public static List<Student> OrderByStudentFirstName(this List<Student> list)
        {
            list =
                (from student in list
                 orderby student.FirstName
                 select student)
                 .ToList();

            return list;
        }

        public static List<Student> OrderByStudentFirstNameLINQ(this List<Student> list)
        {
            list = list.OrderBy(student => student.FirstName).ToList();
            return list;
        }

        public static List<Student> OrderByStudentGroupNumber(this List<Student> list)
        {
            list =
                (from student in list
                 orderby student.GroupNumber ascending
                 select student).ToList();

            return list;
        }

        public static List<Student> GetStudentsWithFirstBeforeLast(this List<Student> list)
        {
            var output = list.Where(stu => stu.FirstName.CompareTo(stu.LastName) < 0).ToList();

            return output;
        }

        public static List<Student> GetStudentsWithinAgeRange(this List<Student> list, int min, int max)
        {
            var output = list.Where(stu => stu.Age >= min && stu.Age <= max).ToList();

            return output;
        }

        public static List<Student> GetStudentsByGroup(this List<Student> list, int group)
        {
            var output =
                from student in list
                where student.GroupNumber == 2
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

        public static List<Student> GetStudentsByTwoMarks(this List<Student> list, int mark, int occurnaces)
        {
            Func<List<int>, bool> Check = (studentMarks) =>
                studentMarks.Where(m => m == mark).Count() == occurnaces;

            var output = list
                .Where(student => Check(student.Marks))
                .ToList();

            return output;
        }

        public static List<List<int>> GetMarksOfStudentsByYear(this List<Student> list, string YY)
        {
            Func<int, bool> Check = (fn) =>
            {
                var studentYear = fn.ToString().Substring(4, 2);
                return studentYear == YY;
            };

            var output = list.Where(student => Check(student.FN)).Select(student => student.Marks).ToList();

            return output;
        }

        /// <summary>
        /// List .Join(
        ///     List to join with (filtered in this case),
        ///     Match Property GroupNumber in Student objects
        ///     with  Property GroupNumber in Group objects
        ///     Return new anonymous type or student in this case
        /// </summary>
        /// <param name="list"></param>
        /// <param name="groups"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        public static List<Student> GetStudentsByDepartment
            (this List<Student> list, List<Group> groups, DepartmentsType department)
        {

            var output = list.Join(
                groups.Where(group => group.DepartmentName == DepartmentsType.Mathematics).ToList(),
                student => student.GroupNumber,
                group => group.GroupNumber,
                (student, group) => student)
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

        #endregion

        #region Homework Utilities
        public static string[] ConvertToStringArray(this List<Student> list)
        {
            var output = new string[list.Count];

            for (int index = 0; index < list.Count; index++)
            {
                output[index] = list[index].ToString();
            }

            return output;
        }
        #endregion

        #region Save/ Load from File
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
                            GroupNumber = int.Parse(data[5]),
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
                throw new Exception("Follow the instructions in Readme.txt");
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

        /// <summary>
        /// Modify FN Property from old input (1, 2 ,3 ,4 etc)
        /// to a format according to homework assignment (nnnnYYnn)
        /// FirstName FirstLetter Square + YY + LastName FirstLetter Square.Substring(0, 2)
        /// to a length of 8 ( to fit into int32 )
        /// Save everything to a new file for input.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="rng"></param>
        public static void ModfiyFN(this List<Student> list, Random rng)
        {
            var output = new List<Student>();

            for (int index = 0; index < list.Count; index++)
            {
                var newFN = new StringBuilder();

                var letter1 = list[index].FirstName[0];
                var letter2 = list[index].LastName[0];

                var year = rng.Next(3, 12).ToString("D2");

                newFN.Append((int)(letter1 * letter1));
                newFN.Append(year);
                newFN.Append((int)(letter1 * letter1));

                list[index].FN = int.Parse(newFN.Substring(0, 8).ToString());
                output.Clear();
            }
        }
        #endregion
    }
}