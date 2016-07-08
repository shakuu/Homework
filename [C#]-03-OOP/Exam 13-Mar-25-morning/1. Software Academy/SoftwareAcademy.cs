
namespace SoftwareAcademy
{
    using System;
    using System.Linq;
    using System.Text;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    using System.Reflection;

    using System.Collections.Generic;

    internal class Teacher : ITeacher
    {
        private string name;

        private ICollection<ICourse> teachingCourses;

        public Teacher(string name)
        {
            this.teachingCourses = new LinkedList<ICourse>();

            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                // TODO: Validate
                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.teachingCourses.Add(course);
        }

        public override string ToString()
        {
            var coursesNames = this.teachingCourses.Select(course => course.Name).Take(this.teachingCourses.Count);

            // Teacher: Name=(teacher name); Courses=[(course names – comma separated)]
            var stringToReturn = string.Format(
                "Teacher: Name={0}",
                this.Name);

            if (this.teachingCourses.Count > 0)

            {
                stringToReturn += string.Format("; Courses=[{0}]", string.Join(", ", coursesNames));
            }

            return stringToReturn;
        }
    }

    internal class Course : ICourse
    {
        private string name;
        private ITeacher assignedTeacher;
        private ICollection<string> listOfTopics;

        public Course(string name, ITeacher teacher)
        {
            this.listOfTopics = new LinkedList<string>();

            this.Name = name;
            this.Teacher = teacher;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                // TODO: Validate
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.assignedTeacher;
            }

            set
            {
                // TODO: Validate.
                this.assignedTeacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.listOfTopics.Add(topic);
        }

        public override string ToString()
        {
            // (course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)];
            var stringToReturn = string.Format("{0}: Name={1}", this.GetType().Name, this.Name);

            if (this.Teacher != null)
            {
                stringToReturn += string.Format("; Teacher={0}", this.Teacher.Name);
            }

            if (this.listOfTopics.Count > 0)
            {
                stringToReturn += string.Format("; Topics=[{0}]", string.Join(", ", this.listOfTopics));
            }

            return stringToReturn;
        }
    }

    class LocalCourse : Course, ILocalCourse
    {
        private string labUsed;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.labUsed;
            }

            set
            {
                // TODO: Validate
                this.labUsed = value;
            }
        }

        public override string ToString()
        {
            var stringToReturn = base.ToString();

            // Lab=(lab name – when applicable);
            stringToReturn += string.Format("; Lab={0}", this.Lab);

            return stringToReturn;
        }
    }

    class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                // TODO: Validate
                this.town = value;
            }
        }

        public override string ToString()
        {
            var stringToReturn = base.ToString();

            //Town=(town name – when applicable);
            stringToReturn += string.Format("; Town={0}", this.Town);

            return stringToReturn;
        }
    }

    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public interface ICourse
    {
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        void AddTopic(string topic);
        string ToString();
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }

    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        static void Main()
        {

            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);

        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
