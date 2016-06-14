
namespace Homework3.Students
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PointAndMatrix.Lists;
    using TimedEvent;

    public class Student
    {
        #region Fields
        private string first;
        private string last;
        private string email;
        private string tel;
        private int group;
        private int fn;
        private int age;

        private List<int> marks;

        private GenericList<Course> courses;
        #endregion
        #region Constructors
        public Student()
        {
            this.marks = new List<int>();
            this.courses = new GenericList<Course>();
        }

        public Student(string first, string last)
            : this()
        {
            this.FirstName = first;
            this.LastName = last;
        }

        // Constructor subscribed to Timer event
        public Student(string first, string last, Timer timer)
            : this(first, last)
        {
            timer.TimedEvent += OnTimedEvent;
        }
        #endregion
        #region Properties
        public string FirstName
        {
            get
            {
                return this.first;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Empty string");
                }

                this.first = value;
            }

        }

        public string LastName
        {
            get
            {
                return this.last;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Empty string");
                }

                this.last = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Empty string");
                }

                this.email = value;
            }

        }

        public string Tel
        {
            get
            {
                return this.tel;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Empty string");
                }

                this.tel = value;
            }

        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public int FN
        {
            get
            {
                return this.fn;
            }
            set
            {
                this.fn = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.group;
            }
            set
            {
                this.group = value;
            }
        }

        public int CoursesCount
        {
            get
            {
                return this.courses.Count;
            }
        }

        public List<int> Marks
        {
            get
            {
                return this.marks;
            }
            set
            {
                this.marks = value;
            }
        }

        #endregion
        #region Methods
        public Course GetCourseInfo(int index)
        {
            return this.courses[index];
        }

        public void AddCourseInfo(string name, int mark)
        {
            this.courses.Add(new Course(name, mark));
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            var separator = "|";
            //FirstName|LastName|FN|Phone|Email|Group|Marks|Marks|Marks|Marks
            output.Append(this.FirstName);
            output.Append(separator + this.LastName );
            output.Append(separator + this.FN );
            output.Append(separator + this.Tel);
            output.Append(separator + this.Email);
            output.Append(separator + this.GroupNumber);

            foreach (var mark in this.Marks)
            {
                output.Append(separator + mark);
            }

            return output.ToString();
        }
        #endregion
        #region Events
        void OnTimedEvent(object sender, EventArgs args)
        {
            Console.WriteLine(sender);
            Console.WriteLine(this.FirstName + " " + this.LastName);
        }
        #endregion
    }
}
