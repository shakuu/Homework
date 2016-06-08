
namespace SchoolClasses
{
    using System.Collections.Generic;
    using Validation.ValidateString;
    using People;
    using System.Linq;
    using System;

    class School
    {
        private List<SchoolClass> classes;
        private List<Teacher> teachers;
        private string name;

        #region Constructors
        public School()
        {
            this.classes = new List<SchoolClass>();
            this.teachers = new List<Teacher>();
        }

        public School(string name)
            : this()
        {
            this.Name = name;
        }
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                ValidateStrings.ValidateName(value);
                this.name = value;
            }
        }

        public List<SchoolClass> SchoolClasses
        {
            get
            {
                return this.classes;
            }
            private set
            {
                this.classes = value;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
            set
            {
                this.teachers = value;
            }
        }
        #endregion

        public void AddClass(SchoolClass newClass)
        {
            var check = this.SchoolClasses.Where(schoolClass => schoolClass.ID == newClass.ID).Count();

            if (check > 0)
            {
                throw new ArgumentException("Class IDs must be unique");
            }
            else
            {
                this.SchoolClasses.Add(newClass);
            }
        }
    }
}
