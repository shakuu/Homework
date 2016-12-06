using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates2
{
    class Program
    {
        private static List<double> currencyOneRates = new List<double>();
        private static List<double> currencyTwoRates = new List<double>();
        private static int daysCount;

        private static double initialAmount;
        private static double maxAmount;

        public static void Main()
        {
            initialAmount = double.Parse(Console.ReadLine());
            maxAmount = -1;

            daysCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < daysCount; i++)
            {
                var rates = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();

                currencyOneRates.Add(rates[0]);
                currencyTwoRates.Add(rates[1]);
            }

            var results = new double[daysCount, daysCount + 1];
            for (int row = 0; row < daysCount; row++)
            {
                results[row, 0] = initialAmount * currencyOneRates[row];
            }

            for (int row = 0; row < daysCount - 1; row++)
            {
                for (int col = row + 2; col < daysCount + 1; col++)
                {
                    results[row, col] = results[row, 0] * currencyTwoRates[col - 1];

                    if (maxAmount < results[row, col])
                    {
                        maxAmount = results[row, col];
                    }
                }
            }

            Console.WriteLine("{0:F2}", maxAmount);
        }
    }
}
