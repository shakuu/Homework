
namespace SchoolClasses.People
{
    using Validation.ValidateString;

    public class Student : Person
    {
        private string id;

        public Student(string name, string id)
            : base(name)
        {
            this.ClassNumber = id;
        }

        public string ClassNumber
        {
            get
            {
                return this.id;
            }
            set
            {
                ValidateStrings.ValidateStudentID(value);
                this.id = value;
            }
        }
    }
}
