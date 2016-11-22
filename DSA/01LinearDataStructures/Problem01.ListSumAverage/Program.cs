using System;
using System.Collections.Generic;

namespace Problem01.ListSumAverage
{
    public class Program
    {
        public static void Main()
        {
            var readNumbers = new List<int>();
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                int nextValue;
                var isParsed = int.TryParse(input, out nextValue);
                if (isParsed)
                {
                    readNumbers.Add(nextValue);
                }
            }

            int sum = 0;
            foreach (var value in readNumbers)
            {
                try
                {
                    sum += value;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Overflow at {sum}");
                }
            }

            Console.WriteLine($"Sum: {sum}, Avg: {sum / readNumbers.Count}");
        }
    }
}
