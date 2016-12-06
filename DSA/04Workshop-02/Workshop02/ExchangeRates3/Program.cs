using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates3
{
    class Program
    {
        private static List<double> currencyOneRates = new List<double>();
        private static List<double> currencyTwoRates = new List<double>();
        private static int daysCount;

        private static double initialAmount;

        public static void Main()
        {
            initialAmount = double.Parse(Console.ReadLine());

            daysCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < daysCount; i++)
            {
                var rates = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();


                if (i != daysCount - 1)
                {
                    currencyOneRates.Add(rates[0]);
                    initialAmount *= rates[0];
                }

                if (i != 0)
                {
                    initialAmount *= rates[1];
                    currencyTwoRates.Add(rates[1]);
                }
            }

            while (true)
            {
                var minC1Rate = currencyOneRates.Min();
                var minC1RateIndex = currencyOneRates.IndexOf(minC1Rate);
                var minC2Rate = currencyTwoRates.Skip(minC1RateIndex).Min();

                var newAmount = initialAmount / minC1Rate / minC2Rate;
                if (newAmount <= initialAmount)
                {
                    break;
                }
                else
                {
                    initialAmount = newAmount;
                    currencyOneRates.Remove(minC1Rate);
                    currencyTwoRates.Remove(minC2Rate);
                }
            }

            Console.WriteLine("{0:F2}", initialAmount);
        }
    }
}
