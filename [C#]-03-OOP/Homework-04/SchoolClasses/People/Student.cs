
namespace SchoolClasses.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Validation;

    /// <summary>
    ///  ID must be unique for the student out
    ///  of the students in his class. ( that's how school works ? )
    ///  OR unique overall ( as a university number ) ? 
    /// </summary>
    public class Student : Person
    {
        private string id;

        public Student(string name, string id)
            : base(name)
        {

        }

        public string ClassNumber
        {
            get
            {
                return this.id;
            }
            set
            {
                // TODO: Add validation once
                // there are classes of students
                this.id = value;
            }
        }
    }
}
