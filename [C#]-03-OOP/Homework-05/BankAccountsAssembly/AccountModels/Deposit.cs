namespace BankAccountsAssembly.AccountModels
{
    using CustomerModels.AbstractModels;
    using Interfaces;
    using System;

    public class Deposit : AbstractModels.Account, IWithdraw
    {
        public Deposit(Customer customer, decimal balance, decimal rate)
            : base(customer, balance, rate)
        {
        }

        public void WithdrawMoney(decimal amount)
        {
            if (this.Balance - amount < 0)
            {
                throw new ArgumentOutOfRangeException("Whithdraw amount must be higher than current account balance");
            }
            else
            {
                this.Balance -= amount;
            }
        }

        protected override decimal CalculateIndividualInterest(int period)
        {
            decimal result = 0;

            if (this.Balance >= 0 && this.Balance < 1000)
            {
                result = 0;
            }
            else
            {
                result = period * this.InterestRate;
            }

            return result;
        }
        protected override decimal CalculateCompanyInterest(int period)
        {
            return CalculateIndividualInterest(period);
        }
    }
}
