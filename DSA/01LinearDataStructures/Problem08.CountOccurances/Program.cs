using System;
using System.Collections.Generic;

namespace Problem08.CountOccurances
{
    public class Program
    {
        public static void Main()
        {
            var inputValues = new List<int>();
            while (true)
            {
                var nextLine = Console.ReadLine();
                if (string.IsNullOrEmpty(nextLine))
                {
                    break;
                }

                int nextValue;
                var isParsed = int.TryParse(nextLine, out nextValue);
                if (isParsed)
                {
                    inputValues.Add(nextValue);
                }
            }

            var occurancesCounters = new Dictionary<int, int>();
            foreach (var value in inputValues)
            {
                var keyExists = occurancesCounters.ContainsKey(value);
                if (keyExists)
                {
                    occurancesCounters[value]++;
                }
                else
                {
                    occurancesCounters.Add(value, 1);
                }
            }

            foreach (var item in occurancesCounters)
            {
                Console.WriteLine($"Value: {item.Key}, Count: {item.Value}");
            }
        }
    }
}
