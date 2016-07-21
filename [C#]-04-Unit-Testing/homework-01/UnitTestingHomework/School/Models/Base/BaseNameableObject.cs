namespace School.Models.Base
{
    using System;

    using School.Contracts;
    using School.Utils;

    public class BaseNameableObject : INameable
    {
        private string name;

        public BaseNameableObject(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (Validation.CheckIfStringIsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }
    }
}
