using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever
{
    public class GoldFever
    {
        public static void Main(string[] args)
        {
            var daysCount = int.Parse(Console.ReadLine());
            var prices = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var listOfSales = new LinkedList<long>();

            var averagePrice = prices.Average();

            long currentOunces = 0;
            long currentProfit = 0;

            long possibleOunces = 0;
            long possibleProfit = 0;
            long possibleCost = 0;

            long allOunces = 0;
            long allCost = 0;

            long bestOunces = 0;
            long bestProfit = 0;

            for (int dayNumber = 0; dayNumber < daysCount; dayNumber++)
            {
                var currentPrice = prices[dayNumber];
                if (currentPrice <= averagePrice && dayNumber != daysCount - 1)
                {
                    possibleOunces++;
                    possibleCost -= currentPrice;

                    currentOunces++;
                    currentProfit -= currentPrice;
                }
                else
                {
                    var potentialProfit = possibleOunces * currentPrice + possibleCost;

                    currentProfit += currentOunces * currentPrice;

                    if (currentProfit < potentialProfit)
                    {
                        currentProfit = potentialProfit;
                    }

                    currentOunces = 0;
                }

                var allOuncesProfit = allOunces * currentPrice + allCost;
                if (currentProfit < allOuncesProfit)
                {
                    currentProfit = allOuncesProfit;
                    currentOunces = 0;
                }

                allOunces++;
                allCost -= currentPrice;
            }

            if (currentProfit < 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(currentProfit);
            }

            //double averagePriceOne = 0;
            //double averagePriceTwo = 0;

            //var currentOuncesOne = 1;
            //var currentProfitOne = -prices[0];

            //var currentOuncesSell = 0;
            //var currentProfitSell = 0;

            ////  buy one ounce, sell any number
            //for (int dayNumber = 1; dayNumber < daysCount; dayNumber++)
            //{
            //    // buy
            //    var tempSellProfit = currentProfitSell - prices[dayNumber];


            //    // sell
            //    var tempBuyProfit = currentOuncesOne * prices[dayNumber];
            //    if (currentProfitOne < tempBuyProfit)
            //    {
            //        currentProfitOne = tempBuyProfit;
            //        currentOuncesOne = 0;
            //    }
            //}
        }
    }
}
