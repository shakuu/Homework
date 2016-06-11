namespace BankAccountsAssembly.CustomerModels.AbstractModels
{
    using System;

    public abstract class Customer
    {
        private string name;

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value is empty");
                }
                else if (value.Length > 30)
                {
                    throw new ArgumentException("Name is too long");
                }
                this.name = value;
            }
        }
    }
}
