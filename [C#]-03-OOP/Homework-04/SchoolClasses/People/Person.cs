
namespace SchoolClasses.People
{
    using System;
    using Interfaces;
    using Validation.ValidateString;
    /// <summary>
    /// Figure out how to validate comments.
    /// List of forbidden words ? 
    /// </summary>
    public class Person : INameable, ICommentable
    {
        private string name;
        private string comment;

        protected Person (string name)
        {
            this.Name = name;
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

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                ValidateStrings.ValidateName(value);
                this.name = value;
            }
        }
        #endregion
    }
}
