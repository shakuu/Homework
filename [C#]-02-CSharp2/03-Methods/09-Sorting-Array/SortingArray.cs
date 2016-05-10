using System;
using System.Linq;

namespace _09_Sorting_Array
{
    class SortingArray
    {
        static void Main()
        {
            // TODO: 90 / 100

            // input
            Console.ReadLine();     // Size of the array

            // get array
            int[] toSort = Console.ReadLine()
                           .Trim(' ')
                           .Split(' ')
                           .Select(number => int.Parse(number))
                           .ToArray();

            // sort Ascending/ Descending
            toSort = SortAscending(toSort);

            // output
            Console.WriteLine(string.Join(" ", toSort));
        }

        // GetMax
        public static int GetMax(
                      int[] toSort,
                      int StartAt,
                      int StopAt)
        {
            int MaxNumberIndex = -1;
            int MaxNumber = int.MinValue;

            for (int curElement = StartAt;
                     curElement <= StopAt;
                     curElement++)
            {
                if (toSort[curElement] > MaxNumber)
                {
                    MaxNumberIndex = curElement;
                    MaxNumber = toSort[curElement];
                }
            }

            // return the index
            return MaxNumberIndex;
        }

        // Sort Descending - Sort Array Left to Right
        public static int[] SortDescending(int[] toSort)
        {
            // For each element
            for (int CurElement = 0;
                 CurElement < toSort.Length;
                 CurElement++)
            {
                var curMaxIndex = GetMax(toSort, CurElement, toSort.Length - 1);

                if (CurElement != curMaxIndex)
                {
                    toSort[CurElement] ^= toSort[curMaxIndex];
                    toSort[curMaxIndex] ^= toSort[CurElement];
                    toSort[CurElement] ^= toSort[curMaxIndex];
                }
            }

            return toSort;
        }

        // Sort Ascending - Sort Array Right to Left
        public static int[] SortAscending(int[] toSort)
        {
            //SortAscending
            for (int CurElement = toSort.Length - 1;
                     CurElement >= 0;
                     CurElement--)
            {
                var curMaxIndex = GetMax(toSort, 0, CurElement);

                if (CurElement != curMaxIndex)
                {
                    toSort[CurElement] ^= toSort[curMaxIndex];
                    toSort[curMaxIndex] ^= toSort[CurElement];
                    toSort[CurElement] ^= toSort[curMaxIndex];
                }
            }

            return toSort;
        }
    }
}
