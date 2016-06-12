namespace BankAccountsAssembly.AccountModels.AbstractModels
{
    using CustomerModels.AbstractModels;
    using Interfaces;
    using System;
    using System.Reflection;
    using Types;

    public delegate decimal Test(int period);

    public abstract class Account : IRate, IDeposit
    {
        private Customer customer;
        private decimal balance;
        private decimal rate;
        private CustomerType customerType;

        #region Constructor
        public Account(Customer customer, decimal balance, decimal rate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = rate;
            this.SetCustomerType(customer.GetType());
        }
        #endregion

        #region Properties
        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            protected set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.rate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("InterestRate must be positive or 0");
                }
                this.rate = value;
            }
        }

        protected CustomerType CustomerType { get; private set; }
        #endregion

        public decimal CalculateInterest(int period)
        {
            var format = "Calculate{0}Interest";
            var name = string.Format(format, this.Customer.GetType().Name);
            var method = this.GetType().GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance);

            var result = (decimal)method.Invoke(this, new object[] { period });

            return result;
        }

        protected abstract decimal CalculateIndividualInterest(int period);
        protected abstract decimal CalculateCompanyInterest(int period);

        public virtual void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        private void SetCustomerType(Type type)
        {
            CustomerType temp;
            if (CustomerType.TryParse(type.Name, out temp)) this.CustomerType = temp;
            else throw new ArgumentException("Unknown Customer Type");
        }
    }
}
