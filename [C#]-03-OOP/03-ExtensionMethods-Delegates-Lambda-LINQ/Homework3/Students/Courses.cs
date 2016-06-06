
namespace Homework3.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Course
    {
        private string name;
        private int mark;

        public Course(string name, int mark)
        {
            this.Name = name;
            this.Mark = mark;
        }

        public string  Name { get; set; }
        public int  Mark { get; set; }
    }
}
