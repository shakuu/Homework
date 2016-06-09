
namespace SchoolClasses.People
{
    using Interfaces;
    using Validation.ValidateStrings;

    public abstract class Person : INameable, ICommentable
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
                ValidateString.ValidateComment(value);
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
                ValidateString.ValidateName(value);
                this.name = value;
            }
        }
        #endregion
    }
}
