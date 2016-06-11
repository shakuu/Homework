namespace BankAccountsAssembly.AccountModels.AbstractModels
{
    using CustomerModels.AbstractModels;
    using Interfaces;
    using System;
    using Types;

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

        public decimal Balance {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate {
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
            decimal result = 0;

            switch (this.CustomerType)
            {
                case Types.CustomerType.Individual:
                    result = CalculateIndividualInterest(period);
                    break;
                case Types.CustomerType.Company:
                    result = CalculateCompanyInterest(period);
                    break;
                default:
                    throw new ArgumentException("Unknown cutomer type");
            }

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
            if (type == typeof(CustomerModels.Company))
            {
                this.CustomerType = CustomerType.Company;
            }
            else if (type == typeof(CustomerModels.Individual))
            {
                this.CustomerType = CustomerType.Individual;
            }
            else
            {
                throw new ArgumentException("Unknown Cutomer Type");
            }
        }
    }
}
