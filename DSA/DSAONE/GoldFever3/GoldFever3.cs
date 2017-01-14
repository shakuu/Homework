using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever3
{
    public class GoldFever3
    {
        public static void Main()
        {
            var daysCount = int.Parse(Console.ReadLine());
            var quotes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            // item1 = profit, item2 = ounces
            var currentBestBuy = new Tuple<double, double>(-quotes[0], 1);
            var currentBestSell = new Tuple<double, double>(0, 0);

            for (int quoteIndex = 1; quoteIndex < quotes.Length; quoteIndex++)
            {
                var nextQuote = quotes[quoteIndex];

                var bestBuyBuy = new Tuple<double, double>(currentBestBuy.Item1 - nextQuote, currentBestBuy.Item2 + 1);
                var bestSellBuy = new Tuple<double, double>(currentBestSell.Item1 - nextQuote, currentBestSell.Item2 + 1);

                var bestCoefficient = Math.Abs(currentBestBuy.Item1 / currentBestBuy.Item2);
                var bestBuyCoefficient = Math.Abs(bestBuyBuy.Item1 / bestBuyBuy.Item2);
                if (bestBuyCoefficient <= bestCoefficient)
                {
                    if (bestBuyCoefficient == bestCoefficient)
                    {
                        currentBestBuy = currentBestBuy.Item2 >= bestBuyBuy.Item2 ? currentBestBuy : bestBuyBuy;
                    }
                    else
                    {
                        currentBestBuy = bestBuyBuy;
                    }
                }

                var bestSellCoefficient = Math.Abs(bestSellBuy.Item1 / bestSellBuy.Item2);
                if (bestBuyCoefficient <= bestCoefficient)
                {
                    if (bestBuyCoefficient == bestCoefficient)
                    {
                        currentBestBuy = currentBestBuy.Item2 >= bestSellBuy.Item2 ? currentBestBuy : bestSellBuy;
                    }
                    else
                    {
                        currentBestBuy = bestSellBuy;
                    }
                }

                var bestSaleCoefficient = Math.Abs(currentBestSell.Item1 / currentBestSell.Item2);
                if (bestBuyCoefficient <= bestCoefficient)
                {
                    if (bestBuyCoefficient == bestCoefficient)
                    {
                        currentBestBuy = currentBestBuy.Item2 >= currentBestSell.Item2 ? currentBestBuy : currentBestSell;
                    }
                    else
                    {
                        currentBestBuy = currentBestSell;
                    }
                }

                var bestBuySell = new Tuple<double, double>((currentBestBuy.Item2 * nextQuote) + currentBestBuy.Item1, 0);
                if (currentBestSell.Item1 < bestBuySell.Item1)
                {
                    currentBestSell = bestBuySell;
                }

                var bestSellSell = new Tuple<double, double>((currentBestSell.Item2 * nextQuote) + currentBestSell.Item1, 0);
                if (currentBestSell.Item1 < bestSellSell.Item1)
                {
                    currentBestSell = bestSellSell;
                }
            }
        }
    }
}
