
namespace SchoolClasses.Disciplines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Validation.ValidateString;
    using Validation.ValidateInt;

    public class Discipline : INameable, ICommentable
    {
        private string name;
        private string comment;
        private int lectures;
        private int excercises;

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

        public int NumberOfLectures
        {
            get
            {
                return this.lectures;
            }
            set
            {
                ValidateInts.ValidateNumberOfLectures(value);
                this.excercises = value;
            }
        }

        public int NumberOfExcercises
        {
            get
            {
                return this.excercises;
            }
            set
            {
                ValidateInts.ValidateNumberOfExcercises(value);
                this.excercises = value;
            }
        }
        #endregion
    }
}
