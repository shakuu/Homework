namespace BankAccountsAssembly.AccountModels
{
    using AbstractModels;
    using CustomerModels.AbstractModels;

    public class Loan : Account
    {
        private const int IndividualNoInterestMonths = 3;
        private const int CompanyNoInterestMonths = 2;

        public Loan(Customer customer, decimal balance, decimal rate)
            : base(customer, balance, rate)
        {
        }

        protected override decimal CalculateIndividualInterest(int period)
        {
            decimal result = 0;

            if (period <= IndividualNoInterestMonths)
            {
                result = 0;
            }
            else
            {
                result = (period - IndividualNoInterestMonths) * this.InterestRate;
            }

            return result;
        }
        protected override decimal CalculateCompanyInterest(int period)
        {
            decimal result = 0;

            if (period <= CompanyNoInterestMonths)
            {
                result = 0;
            }
            else
            {
                result = (period - CompanyNoInterestMonths) * this.InterestRate;
            }

            return result;
        }
    }
}
