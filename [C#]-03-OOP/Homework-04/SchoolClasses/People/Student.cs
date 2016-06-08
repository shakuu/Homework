
namespace SchoolClasses.People
{
    using System;

    public class Student : Person
    {
        private const int MinClassNumber = 1;
        private const int MaxClassNumber = 50;

        private int id;

        public Student(string name, int id)
            : base(name)
        {
            this.ClassNumber = id;
        }

        public int ClassNumber
        {
            get
            {
                return this.id;
            }
            set
            {
                if (!(MinClassNumber <= value && value <= MaxClassNumber))
                {
                    throw new ArgumentException("Student Class Number must be between 1 and 50");
                }
                else
                {
                    this.id = value;
                }
            }
        }
    }
}
