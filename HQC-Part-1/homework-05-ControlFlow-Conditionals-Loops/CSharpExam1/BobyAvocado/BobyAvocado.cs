using System;

namespace CSharpExam1.Task5
{
    public class BobyAvocado
    {
        public static void Main()
        {
            var bobbysHead = uint.Parse(Console.ReadLine());
            var bobbysHeadBitValues = GetBobbysHeadBitValues(bobbysHead);
            var numberOfCombsToEvaluate = int.Parse(Console.ReadLine());

            uint bestCombValue = 0;
            int bestCombTeethCount = 0;
            for (int combNumber = 0; combNumber < numberOfCombsToEvaluate; combNumber++)
            {
                var nextCombValue = uint.Parse(Console.ReadLine());

                var combTeethCount = 0;
                var combFitsBobbysHairstyle = true;
                for (int bitIndex = 0; bitIndex < 32; bitIndex++)
                {
                    var currCombBit = (nextCombValue & (uint)(1 << bitIndex)) >> bitIndex;
                    if (bobbysHeadBitValues[bitIndex] == 1 && currCombBit == bobbysHeadBitValues[bitIndex])
                    {
                        combFitsBobbysHairstyle = false;
                        break;
                    }

                    if (currCombBit == 1)
                    {
                        combTeethCount++;
                    }
                }

                // The best comb is the comb with the most teeth ( 1 bits ), 
                // its value is the expected result.
                if (combFitsBobbysHairstyle && combTeethCount > bestCombTeethCount)
                {
                    bestCombValue = nextCombValue;
                    bestCombTeethCount = combTeethCount;
                }
            }

            Console.WriteLine(bestCombValue);
        }

        private static uint[] GetBobbysHeadBitValues(uint value)
        {
            var bitValues = new uint[32];
            for (int bitIndex = 0; bitIndex < bitValues.Length; bitIndex++)
            {
                bitValues[bitIndex] = (value & (uint)(1 << bitIndex)) >> bitIndex;
            }

            return bitValues;
        }
    }
}
