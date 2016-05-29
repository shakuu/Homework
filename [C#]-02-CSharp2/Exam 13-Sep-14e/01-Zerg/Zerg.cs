
namespace _01_Zerg
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    class Zerg
    {
        static Dictionary<string, int> zerg;

        static void BuildDictionary()
        {
            zerg = new Dictionary<string, int>();

            var zergWords = @"Rawr Rrrr Hsst Ssst Grrr Rarr Mrrr Psst Uaah Uaha Zzzz Bauu Djav Myau Gruh"
                .Split(' ').ToArray();

            for (int i = 0; i < zergWords.Length; i++) zerg.Add(zergWords[i], i);
        }

        static BigInteger ZergToDigits()
        {
            var input = Console.ReadLine();

            BigInteger result = 0;

            var toBase = zerg.Count();

            // Can search by capital letter or length
            var length = 4;
            
            for (int digit = 0; digit < input.Length; digit += 4)
            {
                var curDigit = input.Substring(digit, length);

                result = zerg[curDigit] + result * toBase;
            }

            return result;
        }

        static void Main()
        {
            BuildDictionary();
            Console.WriteLine(ZergToDigits());
        }
    }
}