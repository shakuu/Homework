namespace BankAccountsAssembly.AccountModels
{
    using AbstractModels;
    using CustomerModels.AbstractModels;

    public class Mortgage : Account
    {
        private const int IndividualZeroInterestMonths = 6;
        private const int CompanyHalfInterestMonths = 12;

        public Mortgage(Customer customer, decimal balance, decimal rate)
            : base(customer, balance, rate)
        {
        }

        protected override decimal CalculateIndividualInterest(int period)
        {
            decimal result = 0;

            if (period <= IndividualZeroInterestMonths)
            {
                result = period * (this.InterestRate / 2);
            }
            else
            {
                result = (period - IndividualZeroInterestMonths) * this.InterestRate;
            }

            return result;
        }
        protected override decimal CalculateCompanyInterest(int period)
        {
            decimal result = 0;

            if (period <= CompanyHalfInterestMonths)
            {
                result = period * (this.InterestRate / 2);
            }
            else
            {
                result = CompanyHalfInterestMonths * (this.InterestRate / 2);
                period -= 12;
                result += period * this.InterestRate;
            }

            return result;
        }
    }
}
