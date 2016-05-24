
namespace _01_Calculation_Problem
{
    using System;
    using System.Linq;
    using System.Text;

    class CalcProblem
    {
        // Static Helpers for ease of access.
        static int fromBase = 23;

        static string Catphabet = "abcdefghijklmnopqrstuvwxyz"
                .Substring(0, fromBase);

        static void Main()
        {
            // Get Input.
            var input = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(x => x.ToLower())
                .ToArray();

            // Step 1: Get Sum
            // Step 2: Convert to decimal
            var decimalSum = OriginalToDec(input);
            var catphabetSum = DecToCatphabet(decimalSum);

            Console.WriteLine("{0} = {1}", catphabetSum, decimalSum);

        }

        static string DecToCatphabet(int decimalSum)
        {
            var toReturn = new StringBuilder();

            while (decimalSum > 0)
            {
                var curChar = Catphabet[decimalSum % fromBase];

                toReturn.Insert(0, curChar);

                decimalSum /= fromBase;
            }

            return toReturn.ToString();
        }

        static int OriginalToDec(string[] input)
        {
            var totalSum = 0;

            foreach (var word in input)
            {
                var curSum = 0;

                foreach (var letter in word)
                {
                    curSum = Catphabet.IndexOf(letter) + curSum * fromBase;
                }

                totalSum += curSum;
            }

            return totalSum;
        }
    }
}
