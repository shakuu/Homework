
namespace _01_TRES4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Numerics;

    class Program
    {
        // 90/ 100

        static Dictionary<char, string> TRES4 = new Dictionary<char, string>()
        {
            { '0', "LON+" },
            { '1', "VK-" },
            { '2', "*ACAD" },
            { '3', "^MIM" },
            { '4', "ERIK|" },
            { '5', "SEY&" },
            { '6', "EMY>>" },
            { '7', "/TEL" },
            { '8', "<<DON" }
        };

        static string ReplaceDigits(string toReplace)
        {
            var tres4Number = new StringBuilder();

            foreach (var digit in toReplace)
            {
                tres4Number.Append(TRES4[digit]);
            }

            return tres4Number.ToString();
        }

        static string DecimalToAny(BigInteger decimalNumber, int toBase)
        {
            var newNumber = new StringBuilder();

            while (decimalNumber > 0)
            {
                var digitToAdd = decimalNumber % toBase;
                decimalNumber /= toBase;

                newNumber.Insert(0, digitToAdd);
            }

            return newNumber.ToString();
        }

        static void Main()
        {
            // convert dec to TRES4Base
            // replace digits with symbols
            // print

            var inputDecimalNumber = BigInteger.Parse(Console.ReadLine());
            var toBase = TRES4.Count();

            var TRES4digits = DecimalToAny(inputDecimalNumber, toBase);
            var output = ReplaceDigits(TRES4digits);

            Console.WriteLine(output);
        }
    }
}
