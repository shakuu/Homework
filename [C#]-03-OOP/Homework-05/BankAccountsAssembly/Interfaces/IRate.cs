namespace BankAccountsAssembly.Interfaces
{
    public interface IRate
    {
        decimal InterestRate { get; }

        decimal CalculateInterest(int period);
    }
}
