
namespace _01_Kaspichan_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Numerics;

    class Program
    {
        // Variables.
        static int kaspichanBase = 256;
        static Dictionary<int, string> kaspichanNumbers =
            new Dictionary<int, string>();

        static void BuildDictionary()
        {
            var value = new StringBuilder();

            // First 26
            for (int index = 0; index < 26; index++)
            {
                value.Append((char)('A' + index));

                kaspichanNumbers.Add(index, value.ToString());

                value.Clear();
            }

            var multiplier = 26;

            for (int index = 'a'; index <= 'i'; index++)
            {
                for (int i = 0; i < 26; i++)
                {
                    // Append Prefix
                    value.Append((char)index);

                    value.Append(kaspichanNumbers[i]);

                    kaspichanNumbers.Add(multiplier + i, value.ToString());

                    value.Clear();
                }

                multiplier += 26;
            }

            // The Rest
        }
        
        static void Main()
        {
            BuildDictionary();

            var input = BigInteger.Parse(Console.ReadLine());

            if (input == 0) 
            {
                Console.WriteLine(kaspichanNumbers[0]);
                return;
            }

            var output = new StringBuilder();
            while (input > 0)
            {
                var digit = input % kaspichanBase;

                output.Insert(0, kaspichanNumbers[(int)digit]);

                input /= kaspichanBase;
            }

            Console.WriteLine(output);
        }
    }
}
