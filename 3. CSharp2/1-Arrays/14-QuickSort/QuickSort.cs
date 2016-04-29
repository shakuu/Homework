using System;
using System.Collections.Generic;

namespace _14_QuickSort
{
    class QuickSort
    {
        static void Main()
        {
            // input
            int arraySize = int.Parse(Console.ReadLine());

            List<int> toSort = new List<int>();

            for (int i = 0; i < arraySize; i++)
            {
                toSort.Add(int.Parse(Console.ReadLine()));
            }

            ///////////////
            // Variables
            int arrayLeft = 0;
            int arrayRight = toSort.Count - 1;

            toSort = Sort(toSort, arrayLeft, arrayRight);


        }

        public static List<int> Sort(List<int> toSort, int Left, int Right)
        {
            // return if single element
            if (Right-Left<=1)
            {
                return toSort;
            }

            // Step 1: Get Pivot
            int currPivotPos = Left + (Right - Left) / 2;
            int currPivot = toSort[currPivotPos];

            // Check all Elemennts in the current Range
            for (int index = Left; index <= Right; index++)
            {
                // Compare current element to pivot
                // Skip if current position is pivot position
                if (index != currPivotPos)
                {
                    // if current element is larger
                    // move current element right
                    if (toSort[index] > currPivot &&
                        index < currPivotPos)
                    {
                        toSort.Insert(currPivotPos + 1, toSort[index]);
                        toSort.RemoveAt(index);
                        currPivotPos--;
                        index--;
                    }
                    else if (toSort[index] <= currPivot &&
                             index > currPivotPos)
                    {
                        toSort.Insert(currPivotPos, toSort[index]);
                        toSort.RemoveAt(index + 1);
                        currPivotPos++;
                    }
                }
            }

            // Sort Left Of Pivot
            toSort = Sort(toSort, Left, currPivotPos-1);

            // Sort Right of Pivot
            toSort = Sort(toSort, currPivotPos, Right);

            return toSort;
        }
    }
}
