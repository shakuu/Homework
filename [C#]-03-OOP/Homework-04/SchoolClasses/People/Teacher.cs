
namespace SchoolClasses.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Disciplines;
    using Validation;

    public class Teacher : Person
    {
        private List<Discipline> isTeaching;

        public Teacher(string name)
            : base(name)
        {
        }
        
        public List<Discipline> IsTeaching
        {
            get
            {
                return this.isTeaching;
            }
            set
            {
                this.isTeaching = value;
            }
        }
    }
}
