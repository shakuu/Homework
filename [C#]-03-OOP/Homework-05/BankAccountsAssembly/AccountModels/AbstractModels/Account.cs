namespace BankAccountsAssembly.AccountModels.AbstractModels
{
    using CustomerModels.AbstractModels;
    using Interfaces;
    using System;
    using System.Reflection;
    using Types;
    
    public abstract class Account : IRate, IDeposit
    {
        private decimal _rate;

        protected Account(Customer customer, decimal balance, decimal rate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = rate;
            this.SetCustomerType(customer.GetType());
        }
        
        public Customer Customer { get; protected set; }

        public decimal Balance { get; set; }

        public decimal InterestRate
        {
            get
            {
                return this._rate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Interest rate must be positive or 0");
                }
                this._rate = value;
            }
        }

        protected CustomerType CustomerType { get; private set; }
        
        public decimal CalculateInterest(int periodInMonths)
        {
            const string format = "Calculate{0}Interest";
            var name = string.Format(format, this.Customer.GetType().Name);
            var method = this.GetType()
                .GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance);

            var result = (decimal)method.Invoke(this, new object[] { periodInMonths });

            return result;
        }

        protected abstract decimal CalculateIndividualInterest(int periodInMonths);

        protected abstract decimal CalculateCompanyInterest(int periodInMonths);

        public virtual void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        private void SetCustomerType(Type type)
        {
            CustomerType temp;
            if (Enum.TryParse(type.Name, out temp)) this.CustomerType = temp;
            else throw new ArgumentException("Unknown Customer Type");
        }
    }
}
