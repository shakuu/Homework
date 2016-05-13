using System;
using System.Text;
using System.Numerics;

namespace _07_One_Base_To_Any_2
{
    class AnyToAny2
    {
        // 100 / 100 -> Manually calculate POWER in Any to Dec
        // Thanks for the hint
        // https://github.com/TelerikAcademy/CSharp-Part-2/blob/master/Topics/04.%20Numeral-Systems/demos/Live-Demos-May%2010th%2C%202016%2C%20Koce/BaseNToDecimal/Startup.cs
        // Koce - live demo

        static string HexKey = "0123456789ABCDEF";

        static void Main()
        {
            var fromBase = int.Parse(Console.ReadLine());
            var toConvert = Console.ReadLine();
            var toBase = int.Parse(Console.ReadLine());

            var toPrint = "";

            toPrint = AnyToDec(toConvert, fromBase);
            toPrint = DecToAny(toPrint, toBase);

            Console.WriteLine(toPrint);
        }

        static string AnyToDec(string toConvert, int fromBase)
        {
            BigInteger result = 0;

            foreach (var digit in toConvert)
            {
                // from demo
                // sum = digitsToValues[digit] + sum * radix;
                result = (BigInteger)
                    (HexKey.IndexOf(digit.ToString()) + result * fromBase);
            }

            return result.ToString();
        }

        static string DecToAny(string toConvert, int toBase)
        {
            var result = new StringBuilder();

            var decNumber = BigInteger.Parse(toConvert);

            while (decNumber > 0)
            {
                var curDigit = decNumber % toBase;

                result.Insert(0, HexKey[(int)curDigit]);

                decNumber /= toBase;
            }

            return result.ToString();
        }
    }
}
