namespace StudentsAndWorkers.Models
{
    using AbstractModels;

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
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return this.FullName + $", Grade: {this.Grade}";
        }
    }
}
