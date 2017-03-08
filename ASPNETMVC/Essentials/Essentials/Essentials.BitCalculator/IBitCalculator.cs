namespace Essentials.BitCalculator
{
    public interface IBitCalculator
    {
        IBitCalculatorResultsContainer Calculate(int amount, UnitType unitType);
    }
}
