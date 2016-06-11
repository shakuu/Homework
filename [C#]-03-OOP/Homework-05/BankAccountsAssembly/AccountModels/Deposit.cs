namespace BankAccountsAssembly.AccountModels
{
    using CustomerModels.AbstractModels;
    using System;

    public class Deposit : AbstractModels.Account
    {
        public Deposit(Customer customer, decimal balance, decimal rate) 
            : base(customer, balance, rate)
        {
        }

        public override decimal CalculateInterest(int period)
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
    }
}
