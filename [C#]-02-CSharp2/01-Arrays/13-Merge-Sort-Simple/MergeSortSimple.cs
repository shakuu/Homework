using System;
using System.Collections.Generic;
using System.Linq;

namespace _13_Merge_Sort_Simple
{
    class MergeSortSimple
    {
        static void Main()
        {
            // TODO : 70/ 100

            // input 
            int arraySize = int.Parse(Console.ReadLine());

            // fill the array
            int[] toSort = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSort[i] = int.Parse(Console.ReadLine());
            }

            // Variables
            // Divide and Conquer
            // starting with 2 elements
            int curSortLeft = 0;
            int curSortSize = 1 << 1;
            int curSortRight =
                curSortLeft + curSortSize - 1;

            int curNumOfRuns = arraySize / curSortSize;

            if (arraySize % curSortSize > 1)  // TODO: unnecessary at this point
            {
                curNumOfRuns++;
            }

            while (true)
            {
                //For each subsection
                for (int area = 0; area < curNumOfRuns; area++)
                {
                    // current Area Midpoint
                    int curSortMid = (curSortRight - curSortLeft) / 2
                                + curSortLeft;

                    // list<int> current area to merge, 
                    // fresh for each subsection
                    List<int> curAreaLeft = new List<int>();
                    List<int> curAreaRight = new List<int>();

                    //for each element in the Left subsection
                    for (int element = curSortLeft;
                             element <= curSortMid; element++)
                    {
                        //Fill in Left Side
                        curAreaLeft.Add(toSort[element]);
                    }

                    // for each element in the Right subsection
                    // possible out of range 
                    for (int element = curSortMid + 1;
                             element <= curSortRight; element++)
                    {
                        //Fill in RIght Side
                        curAreaRight.Add(toSort[element]);
                    }

                    // Step 2: Merge Sort Left and Right lists
                    int curelement = curSortLeft;

                    while (curAreaLeft.Count > 0 ||
                           curAreaRight.Count > 0)
                    {
                        // Merge Left and Right 
                        // Step 1: Compare Left[0] with Right[0]
                        // Step 2: Assign the value in the arra
                        // Step 3: Remove the value from the list

                        // If Left > 0, Right no elements
                        if (curAreaLeft.Count > 0 &&
                            curAreaRight.Count == 0)
                        {
                            toSort[curelement] = curAreaLeft[0];
                            curAreaLeft.RemoveAt(0);
                        }
                        else if (curAreaLeft.Count == 0 && curAreaRight.Count > 0)
                        {
                            toSort[curelement] = curAreaRight[0];
                            curAreaRight.RemoveAt(0);
                        }
                        else if (curAreaLeft[0] <= curAreaRight[0])
                        {
                            toSort[curelement] = curAreaLeft[0];
                            curAreaLeft.RemoveAt(0); //Remove the assigned element
                        }
                        else if (curAreaLeft[0] > curAreaRight[0])
                        {
                            toSort[curelement] = curAreaRight[0];
                            curAreaRight.RemoveAt(0);
                        }

                        // increment element
                        curelement++;
                    }

                    // Step 3: Move the current Segemnt Positions
                    curSortLeft += curSortSize;
                    curSortRight = Math.Min(
                        curSortRight + curSortSize, arraySize - 1); //account for out of range
                }

                // Step 4: Increase segment Size - 2 - 4 - 8 - 16 etc
                if (curSortSize << 1 <= arraySize)
                {
                    // increase area size, continue
                    curSortSize <<= 1;
                }
                else
                {
                    // merge the last 2 areas
                    break;
                }

                curNumOfRuns = arraySize / curSortSize;

                // If there s a trailing subsection of
                // size = 1 < elements < curSortSize
                if (arraySize % curSortSize > 1)
                { curNumOfRuns++; } // add an additional run

                // Start Left again
                curSortLeft = 0;
                curSortRight = Math.Min(
                               curSortLeft + curSortSize - 1,
                               arraySize);
            }

            // Merge Last two area
            // Area 1: 0 to curSortSize
            // Area 2: everything else
            List<int> areaLeft = new List<int>();
            List<int> areaRest = new List<int>();

            // Step 1: Fill the lists 
            for (int i = 0; i < curSortSize; i++)
            {
                areaLeft.Add(toSort[i]);
            }

            for (int i = curSortSize; i < arraySize; i++)
            {
                areaRest.Add(toSort[i]);
            }

            int elementAt = 0;

            // Step 2: Merge the last two sections
            while (areaLeft.Count > 0 ||
                           areaRest.Count > 0)
            {
                // Merge Left and Right 
                // Step 1: Compare Left[0] with Right[0]
                // Step 2: Assign the value in the arra
                // Step 3: Remove the value from the list

                // If Left > 0, Right no elements
                if (areaLeft.Count > 0 &&
                    areaRest.Count == 0)
                {
                    toSort[elementAt] = areaLeft[0];
                    areaLeft.RemoveAt(0);
                }
                else if (areaLeft.Count == 0 && areaRest.Count > 0)
                {
                    toSort[elementAt] = areaRest[0];
                    areaRest.RemoveAt(0);
                }
                else if (areaLeft[0] <= areaRest[0])
                {
                    toSort[elementAt] = areaLeft[0];
                    areaLeft.RemoveAt(0); //Remove the assigned element
                }
                else if (areaLeft[0] > areaRest[0])
                {
                    toSort[elementAt] = areaRest[0];
                    areaRest.RemoveAt(0);
                }

                // increment element
                elementAt++;
            }

            // Print the Sorted Array
            foreach (var element in toSort)
            {
                Console.WriteLine(element);
            }

            // TEST
            if (toSort[0] == toSort.Min() && 
                toSort[toSort.Count()-1] == toSort.Max())
            {
                Console.WriteLine("YAY");
            }
        }
    }
}
