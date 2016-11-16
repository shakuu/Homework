using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem07.Majorant
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
        }
    }
}
