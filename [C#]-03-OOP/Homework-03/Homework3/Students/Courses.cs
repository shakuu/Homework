
namespace Homework3.Students
{
    using System;

    public class Course
    {
        private string name;
        private int mark;

        public Course(string name, int mark)
        {
            this.Name = name;
            this.Mark = mark;
        }

        #region Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("value is null or empty");
                }

                this.name = value;
            }
        }
        public int Mark
        {
            get
            {
                return this.mark;
            }
            set
            {
                if (mark < 0 || mark > 500)
                {
                    throw new ArgumentException("Mark must be:  0 <= mark <= 500");
                }
                this.mark = value;
            }
        }
        #endregion
    }
}
