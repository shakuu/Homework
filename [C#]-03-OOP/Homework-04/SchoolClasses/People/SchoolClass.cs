
namespace SchoolClasses.People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Validation.ValidateString;
    
    public class SchoolClass : ICommentable
    {
        private string id;
        private string comment;
        private List<Teacher> teachers;
        private List<Student> students;

        public SchoolClass(string id)
        {

        }

        #region Properties
        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                ValidateStrings.ValidateComment(value);
                this.comment = value;
            }
        }

        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                ValidateStrings.ValidateClassID(value);
                this.id = value; 
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

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }
        #endregion
    }
}
