using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism.Courses
{
    public class OffsiteCourse : Course
    {
        public OffsiteCourse(string name)
            : base(name)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public string Town { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}