
namespace StartUp._02_BankAccount_Testing
{
    using System;

    public static class InitialTests
    {
        public static void TestInterest()
        {
            var test = new BankAccountsAssembly.AccountModels.Deposit(
                new BankAccountsAssembly.CustomerModels.Company("name"),
                1500, (decimal)1.5);

            Console.WriteLine();
            Console.WriteLine(test.GetType().Name);
            Console.WriteLine(test.Balance);
            Console.WriteLine(test.InterestRate);
            Console.WriteLine(test.CalculateInterest(15));
        }
    }
}
