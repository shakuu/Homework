using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates
{
    public class Program
    {

        private static List<double> currencyOneRates = new List<double>();
        private static List<double> currencyTwoRates = new List<double>();
        private static int daysCount;

        private static double maxAmount;
        private static double currentAmount;

        public static void Main()
        {
            maxAmount = double.Parse(Console.ReadLine());
            currentAmount = maxAmount;

            daysCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < daysCount; i++)
            {
                var rates = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse).ToArray();

                currencyOneRates.Add(rates[0]);
                currencyTwoRates.Add(rates[1]);
            }

            findMaxAmount(0, true);
            Console.WriteLine("{0:F2}", maxAmount);
        }

        public static void findMaxAmount(int index, bool isCurrencyOne)
        {
            if (maxAmount < currentAmount && isCurrencyOne)
            {
                maxAmount = currentAmount;
            }

            if (index == daysCount)
            {
                return;
            }

            for (int i = index; i < daysCount; i++)
            {
                if (isCurrencyOne && i != daysCount - 1)
                {
                    currentAmount *= currencyOneRates[i];
                    findMaxAmount(i + 1, !isCurrencyOne);
                    currentAmount /= currencyOneRates[i];
                }
                else
                {
                    currentAmount *= currencyTwoRates[i];
                    findMaxAmount(i + 1, !isCurrencyOne);
                    currentAmount /= currencyTwoRates[i];
                }
            }
        }
    }
}
