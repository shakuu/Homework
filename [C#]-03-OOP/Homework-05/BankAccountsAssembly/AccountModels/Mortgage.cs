namespace BankAccountsAssembly.AccountModels
{
    using AbstractModels;
    using CustomerModels.AbstractModels;
    using System;

    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, decimal rate) 
            : base(customer, balance, rate)
        {
        }

        public override decimal CalculateInterest(int period)
        {
            throw new NotImplementedException();
        }

        public override void WithdrawMoney(decimal amount)
        {
            throw new ArgumentException("Not allowed");
        }
    }
}
