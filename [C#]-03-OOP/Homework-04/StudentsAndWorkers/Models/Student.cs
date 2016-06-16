namespace StudentsAndWorkers.Models
{
    using AbstractModels;
    using System;

    public class Student : Human
    {
        private double grade;

        public Student(string first, string last, double grade)
            : base(first, last)
        {
            this.Grade = grade;
        }

        public double Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (!(2 <= value && value <= 6))
                {
                    throw new Exception("Grade must be between 2 and 6");
                }
                else
                {
                    this.grade = value;
                }
            }
        }

        public override string ToString()
        {
            return this.FullName + $", Grade: {this.Grade}";
        }
    }
}
