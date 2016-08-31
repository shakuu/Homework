using System;
using System.Numerics;
using System.Text;

namespace _01_Crypto
{
    public class Crypto
    {
        private const int ValueOneBaseByTaskDefinition = 26;
        private const int ValueTwoBaseByTaskDefinition = 7;
        private const int SolutionBaseByTaskDefinition = 9;

        public static void Main()
        {
            var valueOneBase26 = Console.ReadLine();
            var mathematicalOperation = Console.ReadLine();
            var valueTwoBase7 = Console.ReadLine();

            var valueOneDecimalValue = ConvertAnotherBaseToDecimal(valueOneBase26, Crypto.ValueOneBaseByTaskDefinition);
            var valueTwoDecimalValue = ConvertAnotherBaseToDecimal(valueTwoBase7, Crypto.ValueTwoBaseByTaskDefinition);

            BigInteger mathematicalOperationResult = 0;
            if (mathematicalOperation == "-")
            {
                mathematicalOperationResult = valueOneDecimalValue - valueTwoDecimalValue;
            }
            else
            {
                mathematicalOperationResult = valueOneDecimalValue + valueTwoDecimalValue;
            }

            var solution = ConvertDecimalToAnotherBase(mathematicalOperationResult, Crypto.SolutionBaseByTaskDefinition);
            Console.WriteLine(solution);
        }

        private static BigInteger ConvertAnotherBaseToDecimal(string number, int anotherBase)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            BigInteger convertedValue = 0;
            foreach (var symbol in number)
            {
                var digit = alphabet.IndexOf(symbol);
                convertedValue = digit + (convertedValue * anotherBase);
            }

            return convertedValue;
        }

        private static string ConvertDecimalToAnotherBase(BigInteger number, int anotherBase)
        {
            var convertedValue = new StringBuilder();
            if (number == 0)
            {
                convertedValue.Append(number);
            }
            else
            {
                while (number > 0)
                {
                    var digit = number % anotherBase;
                    number /= anotherBase;

                    convertedValue.Insert(0, digit);
                }
            }

            return convertedValue.ToString();
        }
    }
}
