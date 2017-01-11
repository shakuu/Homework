using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever2
{
    class Program
    {
        static void Main(string[] args)
        {
            var daysCount = int.Parse(Console.ReadLine());
            var prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var maxProfit = 0;
            var maxProfitCost = 0;
            var maxProfitOunces = 0;

            var boughtProfit = -prices[0];
            var boughtOunces = 1;

            var soldProfit = 0;
            var soldOunces = 0;

            var passedProfit = 0;
            var passedOunces = 0;

            var maxTotal = 0;
            var currentTotal = 0;
            var previousTotal = 0;

            for (int i = 1; i < daysCount; i++)
            {
                var currentPrice = prices[i];

                var currentSale = currentPrice * boughtOunces + boughtProfit;
                if (maxProfit < currentSale)
                {
                    maxProfit = currentSale;
                }

                currentTotal = previousTotal + currentSale;
                if (maxTotal < currentTotal)
                {
                    maxTotal = currentTotal;
                    previousTotal = currentTotal;
                }

                boughtProfit += -prices[i];
                boughtOunces++;
            }

            Console.WriteLine(maxProfit >= 0 ? maxProfit : 0);
        }
    }
}
