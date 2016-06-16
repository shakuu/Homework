namespace SchoolClasses.People
{
    using System.Collections.Generic;
    using Disciplines;

    public class Teacher : Person
    {
        private List<Discipline> isTeaching;

        public Teacher(string name)
            : base(name)
        {
            this.isTeaching = new List<Discipline>();
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
