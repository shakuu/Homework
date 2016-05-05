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

            // Run 1: Work, Work, Work
            toSort = QuickSort(arrLeft, arrRight, toSort);
            // Run 2: The Cleaner
            toSort = QuickSort(arrLeft, arrRight, toSort);

            // Print
            Console.WriteLine(
                string.Join(
                    Environment.NewLine,
                    toSort));
        }

        // Sort it 
        public static List<int> QuickSort(     // Sort By Pivot
                           int arrLeft,        // Split By Pivot position
                           int arrRight,       // Pass the two sections 
                           List<int> toSort)   // down recursively
        {
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
               
            while (true)                                     //
            {
                // Step 2: Left Crawler
                while (crawlLeft < crawlRight)               // Start Left
                {                                            // Find the first
                    if (toSort[crawlLeft] >= sortPivot)      // element 
                    {                                        // MORE THAN PIVOT
                        break;                               // and break
                    }                                        //
                    else                                     //
                    {                                        // if not a match
                        crawlLeft++;                         // increment index
                    }                                        //
                }

                // Step 3: Right Crawler
                while (crawlLeft < crawlRight)               // Then Start crawling
                {                                            // right, find an element
                    if (toSort[crawlRight] <= sortPivot)     // LESS THAN PIVOT
                    {                                        // and break
                        break;                               //
                    }                                        //
                    else                                     //
                    {                                        // if not a match
                        crawlRight--;                        // increment index
                    }                                        //
                }

                if (crawlLeft == crawlRight)                 // if the crawlers meet
                {                                            // then break
                    break;                                   // elements sorted by
                }                                            // pivot 


                if (toSort[crawlLeft] == toSort[crawlRight] &&  // If the crawlers
                    toSort[crawlLeft] == sortPivot)             // have found two
                {                                               // equal elements
                    if (crawlLeft < crawlRight)                 // which are also 
                    {                                           // equal to the 
                        crawlLeft++;                            // current Pivot
                    }                                           // then skip the 
                                                                // element on 
                    continue;                                   // the left
                }                                               // continue

                // Step 4: Switch
                toSort[crawlLeft] ^= toSort[crawlRight];     // switch the two elements
                toSort[crawlRight] ^= toSort[crawlLeft];     // the crawlers have found 
                toSort[crawlLeft] ^= toSort[crawlRight];     // around
            }

            // Section is sorted
            if (crawlLeft == arrRight)  // if the crawlers meet at
            {                           // end of the section
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
        public static double GetPivot(   // 2 elements
                      int arrLeft,       // return (double)Average
                      int arrRight,      // 2 < Elements
                      List<int> toSort)  // return Median of first, last and middle
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
                      (arrRight - arrLeft) / 2]
            };

            // sort array - Bitwise Magic Rules!
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
