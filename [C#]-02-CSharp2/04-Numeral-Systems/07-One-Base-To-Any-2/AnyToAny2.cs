using System;
using System.Text;
using System.Numerics;

namespace _07_One_Base_To_Any_2
{
    class AnyToAny2
    {
        // 100 / 100 -> Manually calculate POWER in Any to Dec
        // Thanks for the hint

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

            var onPower = toConvert.Length - 1;

            var curPower = getPow(fromBase, onPower);

            foreach (var digit in toConvert)
            {
                //var curPower = Math.Pow(fromBase, onPower); -> Incrrect results

                result += (BigInteger)
                    (curPower * HexKey.IndexOf(digit.ToString()));

                curPower /= fromBase;
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

        // OMFG
        static BigInteger getPow(int Base, int Power)
        {
            BigInteger result = 1;

            for (int i = 0; i < Power; i++)
            {
                result *= Base;
            }

            return result;
        }
    }
}
