namespace _01_De_Cat_Coding
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Numerics;

    class DeCatCoding
    {
        // GIVEN: 
        static int fromCatBase = 21;
        static int toBase = 26;

        static string AlphabetStr = "abcdefghijklmnopqrstuvwxyz";

        static void Main()
        {
            // Get input.
            var CatInput = Console
                    .ReadLine()
                    .Trim()
                    .Split()
                    .Select(CatWord => DecToHuman(ConvertCatToDec(CatWord)))
                    .ToArray();

            Console.WriteLine(string.Join(" ", CatInput));
        }


        static string ConvertCatToDec(string CatWord)
        {
            BigInteger CatNumber = 0;

            foreach (var letter in CatWord)
            {
                // Koce live demo
                CatNumber = AlphabetStr.IndexOf(letter) + CatNumber * fromCatBase;
            }

            return CatNumber.ToString();
        }

        static string DecToHuman(string CatNumberStr)
        {
            var outputWord = new StringBuilder();

            var CatNumber = BigInteger.Parse(CatNumberStr);

            while (CatNumber > 0)
            {
                var curLetter = (int)(CatNumber % toBase);

                outputWord.Insert(0, AlphabetStr[curLetter]);

                CatNumber /= toBase;
            }

            return outputWord.ToString();
        }
    }
}
