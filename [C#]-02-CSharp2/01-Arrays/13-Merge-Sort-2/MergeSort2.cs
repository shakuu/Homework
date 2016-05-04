using System;
using System.Collections.Generic;
using System.Linq;

namespace _13_Merge_Sort_2
{
    class MergeSort2
    {
        static void Main()
        {
            // TODO: Change Array to List

            // INPUT
            int arrSize = int.Parse(Console.ReadLine());

            // get Array
            var toSearch = new int[arrSize];

            for (int i = 0; i < arrSize; i++)
            {
                toSearch[i] = int.Parse(Console.ReadLine());
            }

            // variables
            var arrLeft = 0;
            var arrRight = toSearch.Length - 1;

            // Split Top to Bot , then Merge on the way up
            Split(arrLeft, arrRight, toSearch);

            // Print the Array
            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    toSearch
                    ));
        }

        public static int[] Split(
                      int arrLeft, 
                      int arrRight,
                      params int[] toSearch)
        {
            if (arrRight - arrLeft <= 0)
            {
                //Console.WriteLine($"section {arrLeft} to {arrRight}");
                return toSearch;
            }

            // Step 1: Split
            // Step 1.1: Get Midpoint 
            var arrMidpoint =
               (arrRight - arrLeft) / 2 + arrLeft;

            // Step 1.2: Pass along the new left/ right
            // Left
            toSearch = Split(arrLeft, arrMidpoint, toSearch);

            // Right 
            toSearch = Split(arrMidpoint + 1, arrRight, toSearch);

            // Step 2: MergeSort
            //Console.WriteLine($"section {arrLeft} to {arrRight}");
            toSearch = Merge(arrLeft, arrRight, arrMidpoint, toSearch);


            // TODO: Return
            return toSearch;
        }

        public static int[] Merge(              // Get the current split groups
                      int arrLeft,              // Sort them by merging the two
                      int arrRight,             // groups 
                      int arrMidpoint,          // Step 1: Read into Lists
                      params int[] toSearch)    // Step 2: Write into the array
        {
            // created the lists
            List<int> arrLeftArea = new List<int>();
            List<int> arrRightArea = new List<int>();

            // fill the lists
            for (int curElement = arrLeft;                // Fill Left Area
                     curElement <= arrMidpoint;           // arrLeft to 
                     curElement++)                        // arrMidpoint
            {                                             //
                arrLeftArea.Add(toSearch[curElement]);    //
            }                                             //
                                                          //
            for (int curElement = arrMidpoint + 1;        // Fill Right Area
                     curElement <= arrRight;              // arrMidpoint + 1
                     curElement++)                        // arrRight
            {                                             //
                arrRightArea.Add(toSearch[curElement]);   //
            }                                             //
                                                          //
                                                          // Merge the Lists
            for (int curElement = arrLeft;                //
                     curElement <= arrRight;              //
                     curElement++)                        //
            {                                             //
                if (arrLeftArea.Count() == 0)             // Case LeftArea
                {                                         // is now Empty
                    toSearch[curElement] =                // assign the element
                             arrRightArea[0];             // from RihtArea
                    arrRightArea.RemoveAt(0);             // Remove that element
                    continue;                             // next cycle step
                }                                         //
                                                          //
                if (arrRightArea.Count() == 0)            // Case RightArea
                {                                         // is now Empty
                    toSearch[curElement] =                // assign the element
                             arrLeftArea[0];              // from LeftArea
                    arrLeftArea.RemoveAt(0);              // Remove that element
                    continue;                             // next cycle step
                }

                if (arrLeftArea[0] <= arrRightArea[0])        // Assign
                {                                             // smaller 
                    toSearch[curElement] = arrLeftArea[0];    // elements
                    arrLeftArea.RemoveAt(0);                  // first
                    continue;                                 //
                }                                             //
                                                              //
                if (arrRightArea[0] < arrLeftArea[0])         //
                {                                             //
                    toSearch[curElement] = arrRightArea[0];   //
                    arrRightArea.RemoveAt(0);                 //
                    continue;                                 //
                }
            }
            
            return toSearch;
        }
    }
}
