namespace BankAccountsAssembly.AccountModels
{
    using AbstractModels;
    using CustomerModels.AbstractModels;
    using System;

    public class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal rate)
            : base(customer, balance, rate)
        {
        }

        public override void WithdrawMoney(decimal amount)
        {
            throw new ArgumentException("Not allowed");
        }

        public override decimal CalculateInterest(int period)
        {
            decimal result = 0;

            switch (this.CustomerType)
            {
                case Types.CustomerType.Individual:
                    break;
                case Types.CustomerType.Company:
                    break;
                default:
                    throw new ArgumentException("Unknown cutomer type");
            }

            return result;
        }

        private decimal CalculateIndividualInterest(int period)
        {
            return 0;
        }

        private decimal CalculateCompanyInterest(int period)
        {
            return 0;
        }
    }
}
