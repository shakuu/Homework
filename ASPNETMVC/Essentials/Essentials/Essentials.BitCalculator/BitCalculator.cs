using System;
using System.Numerics;

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
            var result = this.bitCalculatorResultsContainerEditableFactory.CreateBitCalculatorResultsContainerEditable();

            result.Bytes = this.GetValue(amount, UnitType.Byte, unitType);
            result.KiloBytes = this.GetValue(amount, UnitType.KiloByte, unitType);
            result.MegaBytes = this.GetValue(amount, UnitType.MegaByte, unitType);
            result.GigaBytes = this.GetValue(amount, UnitType.GigaByte, unitType);
            result.TeraBytes = this.GetValue(amount, UnitType.TeraByte, unitType);
            result.PetaBytes = this.GetValue(amount, UnitType.PetaByte, unitType);
            result.ExaBytes = this.GetValue(amount, UnitType.ExaByte, unitType);
            result.ZettaBytes = this.GetValue(amount, UnitType.ZettaByte, unitType);
            result.YottaBytes = this.GetValue(amount, UnitType.YottaByte, unitType);

            return result;
        }

        private string GetValue(int amount, UnitType outputUnitType, UnitType inputUnitType)
        {
            var power = (int)inputUnitType - (int)outputUnitType;

            if (power >= 0)
            {
                return (amount * BigInteger.Pow(2, power)).ToString();
            }
            else
            {
                return ((double)amount / Math.Pow(2, -power)).ToString();
            }
        }
    }
}
