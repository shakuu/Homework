using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;

namespace Essentials.BitCalculator
{
    public class BitCalculator : IBitCalculator
    {
        private readonly IBitCalculatorResultsContainerEditableFactory bitCalculatorResultsContainerEditableFactory;

        private readonly IDictionary<int, BigInteger> positivePowerMemorization;
        private readonly IDictionary<int, double> negativePowerMemorization;

        public BitCalculator(IBitCalculatorResultsContainerEditableFactory bitCalculatorResultsContainerEditableFactory)
        {
            this.bitCalculatorResultsContainerEditableFactory = bitCalculatorResultsContainerEditableFactory;

            this.positivePowerMemorization = new ConcurrentDictionary<int, BigInteger>();
            this.negativePowerMemorization = new ConcurrentDictionary<int, double>();
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
                if (!this.positivePowerMemorization.ContainsKey(power))
                {
                    this.positivePowerMemorization.Add(power, BigInteger.Pow(2, power));
                }

                return (amount * this.positivePowerMemorization[power]).ToString();
            }
            else
            {
                if (!this.negativePowerMemorization.ContainsKey(power))
                {
                    this.negativePowerMemorization.Add(power, Math.Pow(2, -power));
                }

                return ((double)amount / this.negativePowerMemorization[power]).ToString();
            }
        }
    }
}
