using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldFever3Again
{
    public class GoldFever3Again
    {
        private static int daysCount;
        private static int[] quotes;
        private static long bestOutcome;
        private static int bestOutcomeOunces;

        public static void Main()
        {
            daysCount = int.Parse(Console.ReadLine());
            quotes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            //GenerateOutcome(0, 0, 0);
            //GenerateOutcome(0, -quotes[0], 1);

            var profitStack = new Stack<long>();
            profitStack.Push(0);
            profitStack.Push(-quotes[0]);

            var ouncesStack = new Stack<int>();
            ouncesStack.Push(0);
            ouncesStack.Push(1);

            var quotesStack = new Stack<int>();
            quotesStack.Push(0);
            quotesStack.Push(0);

            var nextQuoteIndex = 0;
            while (profitStack.Count > 0)
            {
                var profit = profitStack.Pop();
                var ounces = ouncesStack.Pop();
                var quoteIndex = quotesStack.Pop();

                if (bestOutcome < profit)
                {
                    bestOutcome = profit;
                    bestOutcomeOunces = ounces;
                }

                nextQuoteIndex = quoteIndex + 1;
                if (daysCount <= nextQuoteIndex)
                {
                    continue;
                }

                var nextQuote = GoldFever3Again.quotes[nextQuoteIndex];

                //profitStack.Push(profit);
                //ouncesStack.Push(ounces);
                //quotesStack.Push(nextQuoteIndex);

                profitStack.Push(profit - nextQuote);
                ouncesStack.Push(ounces + 1);
                quotesStack.Push(nextQuoteIndex);

                var sellProfit = (ounces * nextQuote) + profit;
                if (sellProfit >= 0)
                {
                    profitStack.Push(sellProfit);
                    ouncesStack.Push(0);
                    quotesStack.Push(nextQuoteIndex);
                }
            }

            Console.WriteLine(bestOutcome);
        }

        private static void GenerateOutcome(int currentQuoteIndex, long profit, int ounces)
        {
            if (bestOutcome < profit)
            {
                bestOutcome = profit;
            }

            var nextQuoteIndex = currentQuoteIndex + 1;
            if (daysCount <= nextQuoteIndex)
            {
                return;
            }

            var nextQuote = GoldFever3Again.quotes[nextQuoteIndex];
            GoldFever3Again.GenerateOutcome(nextQuoteIndex, profit, ounces);
            GoldFever3Again.GenerateOutcome(nextQuoteIndex, profit - nextQuote, ounces + 1);
            GoldFever3Again.GenerateOutcome(nextQuoteIndex, ounces * nextQuote + profit, 0);
        }
    }
}
