using System;
using System.Collections.Generic;
using System.Linq;

namespace _06SubsetsStrings
{
    public class SubsetsStrings
    {
        private static IList<string> elementsToDisplay;

        public static void Main()
        {
            var elementsCount = int.Parse(Console.ReadLine());
            var combinationLength = int.Parse(Console.ReadLine());

            elementsToDisplay = Enumerable.Range(0, elementsCount).Select(x => Console.ReadLine()).ToArray();
            var numbers = Enumerable.Range(1, combinationLength).ToArray();

            SubsetsStrings.GenerateUniqueCombination(numbers, combinationLength, elementsCount);
        }

        private static void GenerateUniqueCombination(int[] range, int current, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (current > 1)
                {
                    SubsetsStrings.GenerateUniqueCombination(range, current - 1, count);
                }
                else
                {
                    if (!SubsetsStrings.HasDuplicateElements(range))
                    {
                        SubsetsStrings.PrintElements(range);
                    }
                }

                SubsetsStrings.IncrementWithoutDuplicates(range, range.Length - current);
                if (!SubsetsStrings.ValueIsInRange(range, range.Length - current, count))
                {
                    range[range.Length - current]--;
                    break;
                }
            }
        }

        private static void PrintElements(int[] range)
        {
            foreach (var index in range)
            {
                Console.Write($"{SubsetsStrings.elementsToDisplay[index - 1]} ");
            }

            Console.WriteLine();
        }

        private static void IncrementWithoutDuplicates(int[] range, int index)
        {
            var isDuplicate = false;
            do
            {
                range[index]++;
                isDuplicate = false;

                for (int i = 0; i < index; i++)
                {
                    if (range[i] == range[index])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
            }
            while (isDuplicate);
        }

        private static bool HasDuplicateElements(int[] range)
        {
            for (int i = range.Length - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (range[i] == range[j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool ValueIsInRange(int[] range, int index, int maxValue)
        {
            return range[index] <= maxValue;
        }
    }
}
