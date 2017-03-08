namespace Essentials.BitCalculator
{
    public class BitCalculator : IBitCalculator
    {
        private readonly IBitCalculatorResultsContainerEditableFactory bitCalculatorResultsContainerEditableFactory;

        public BitCalculator(IBitCalculatorResultsContainerEditableFactory bitCalculatorResultsContainerEditableFactory)
        {
            this.bitCalculatorResultsContainerEditableFactory = bitCalculatorResultsContainerEditableFactory;
        }

        public IBitCalculatorResultsContainer Calculate(int amount, UnitType unitType)
        {
            return this.bitCalculatorResultsContainerEditableFactory.CreateBitCalculatorResultsContainerEditable();
        }
    }
}
