namespace School.Models.Abstract
{
    using System;

    using School.Contracts;
    using School.Utils;

    public abstract class BaseObject : IName
    {
        private string name;

        public BaseObject(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            private set
            {
                Validation.CheckIfStringIsNullOrEmpty(value);

                this.name = value;
            }
        }
    }
}
