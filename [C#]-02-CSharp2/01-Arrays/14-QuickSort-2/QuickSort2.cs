using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_QuickSort_2
{
    class QuickSort2
    {
        static void Main()
        {
            // input
            int arrSize = int.Parse(Console.ReadLine());

            // get the array, can be an array
            List<int> toSort = new List<int>();

            for (int curInput = 0;
                     curInput < arrSize;
                     curInput++)
            {
                toSort.Add(
                    int.Parse(
                        Console.ReadLine()));
            }

            // Variables
            int arrLeft = 0;
            int arrRight = toSort.Count() - 1;

            // Run 1:
            toSort = QuickSort(arrLeft, arrRight, toSort);
            // Run 2: Sorting out special cases
            toSort = QuickSort(arrLeft, arrRight, toSort);

            // Print
            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    toSort));
        }

        // Sort it 
        public static List<int> QuickSort(
                           int arrLeft,
                           int arrRight,
                           List<int> toSort)
        {
            // STOP WATCH
            //var STOPWATCH = new System.Diagnostics.Stopwatch();

            if (arrRight - arrLeft <= 0)   // Sequence of 1
            {                              // is sorted by
                return toSort;             // definition 
            }                              // return

            double sortPivot = GetPivot(   // Median of current section
                                arrLeft,   // first, last and mid 
                                arrRight,  // element
                                toSort);   // method for convenience

            // Step 1:
            int crawlLeft = arrLeft;                         // Left Crawler index
            int crawlRight = arrRight;                       // Right Crawler indes
                                                             //

            while (true)                                     //
            {
                // Step 2: Left Crawler
                while (crawlLeft < crawlRight)               // Start Left
                {                                            // Find the first
                    if (toSort[crawlLeft] >= sortPivot)      // element 
                    {                                        // MORE THAN PIVOT
                        break;                               //
                    }                                        //
                    else                                     //
                    {                                        //
                        crawlLeft++;                         //
                    }                                        //
                }

                // Step 3: Right Crawler
                while (crawlLeft < crawlRight)               // Then Start crawling
                {                                            // right, find an element
                    if (toSort[crawlRight] <= sortPivot)     // LESS THAN PIVOT
                    {                                        //
                        break;                               //
                    }                                        //
                    else                                     //
                    {
                        crawlRight--;
                    }
                }

                if (crawlLeft == crawlRight)                 // if the crawlers meet
                {                                            // then break
                    break;                                   // elements sorted by
                }                                            // pivot 


                if (toSort[crawlLeft] == toSort[crawlRight] &&
                    toSort[crawlLeft] == sortPivot)
                {
                    if (crawlLeft < crawlRight)
                    {
                        crawlLeft++;
                    }

                    continue;
                }

                // Step 4: Switch
                toSort[crawlLeft] ^= toSort[crawlRight];     // switch the two elements
                toSort[crawlRight] ^= toSort[crawlLeft];     // the crawlers found 
                toSort[crawlLeft] ^= toSort[crawlRight];     // around
            }
            
            // Special Case
            if (crawlLeft == arrRight)  // if crawlers are at the 
            {
                // end of the section
                return toSort;          // then section is 
            }                           // sorted (also infiLoop)

            // Step 5: Pass Along
            toSort = QuickSort(arrLeft, crawlLeft - 1, toSort);  // 1: arrLeft to crawlLeft
            toSort = QuickSort(crawlLeft, arrRight, toSort);     // 2: crawlLeft to arrRight
                                                                 // ( crawlLeft = crawlRight ) 

            // return the current
            // sorted list
            return toSort;
        }

        // Get the current Pivot
        public static double GetPivot(
                      int arrLeft,
                      int arrRight,
                      List<int> toSort)
        {
            // if 2 values, return (double) average
            if (arrRight - arrLeft == 1)
            {
                return (double)
                    (toSort[arrLeft] +
                     toSort[arrRight]) / 2;
            }

            // create array
            int[] Pivot = new int[]
            {
                toSort[arrLeft],
                toSort[arrRight],
                toSort[arrLeft +
                      (arrRight-arrLeft) / 2]
            };

            // sort array
            while (!(Pivot[0] <= Pivot[1] &&
                     Pivot[1] <= Pivot[2]))
            {
                if (Pivot[0] > Pivot[1])
                {
                    Pivot[0] ^= Pivot[1];
                    Pivot[1] ^= Pivot[0];
                    Pivot[0] ^= Pivot[1];
                }

                if (Pivot[1] > Pivot[2])
                {
                    Pivot[1] ^= Pivot[2];
                    Pivot[2] ^= Pivot[1];
                    Pivot[1] ^= Pivot[2];
                }
            }

            // return median
            return Pivot[1];
        }
    }
}
