using Essentials.BitCalculator;

namespace Essentials.Web.Models
{
    public class HomeViewModel
    {
        public int Quantity { get; set; }

        public UnitType UnitType { get; set; }

        public IBitCalculatorResultsContainer BitCalculatorResultsContainer { get; set; }
    }
}