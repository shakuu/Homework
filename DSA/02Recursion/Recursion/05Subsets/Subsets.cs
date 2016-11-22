using System;
using System.Collections.Generic;
using System.Linq;

namespace _05Subsets
{
    public class Subsets
    {
        private static IList<string> elementsToDisplay;

        public static void Main()
        {
            var elementsCount = int.Parse(Console.ReadLine());
            var combinationLength = int.Parse(Console.ReadLine());

            elementsToDisplay = Enumerable.Range(0, elementsCount).Select(x => Console.ReadLine()).ToArray();
            var range = Enumerable.Range(0, combinationLength).Select(x => 1).ToArray();

            Subsets.GenerateCombination(range, combinationLength, elementsCount);
        }

        private static void GenerateCombination(int[] range, int current, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (current > 1)
                {
                    Subsets.GenerateCombination(range, current - 1, count);
                }
                else
                {
                    Subsets.PrintElements(range);
                }

                range[range.Length - current]++;
            }

            range[range.Length - current] = 1;
        }

        private static void PrintElements(int[] range)
        {
            foreach (var index in range)
            {
                Console.Write($"{Subsets.elementsToDisplay[index - 1]} ");
            }

            Console.WriteLine();
        }
    }
}
