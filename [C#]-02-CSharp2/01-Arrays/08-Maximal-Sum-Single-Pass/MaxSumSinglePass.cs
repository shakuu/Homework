using System;
using System.Linq;
using System.Collections;

namespace _08_Maximal_Sum_Single_Pass
{
    class MaxSumSinglePass
    {
        static void Main()
        {
            //input
            int arraySize = int.Parse(Console.ReadLine());

            //get array
            int[] toSearch = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSearch[i] = int.Parse(Console.ReadLine());
            }

            // variables
            BitArray sumFlags = new BitArray(arraySize);
            BitArray maxFlags = new BitArray(arraySize);

            int curSum = 0;
            int maxSum = toSearch.Sum();

            for (int curNumb = 0; curNumb < toSearch.Length; curNumb++)
            {
                // Step 1: Get Current Sum
                curSum += toSearch[curNumb];
                sumFlags.Set(curNumb, true);

                if (curSum > maxSum)
                {
                    // Store the Sum
                    maxSum = curSum;

                    // Flag the indexes
                    maxFlags.SetAll(false);
                    maxFlags.Or(sumFlags);
                }
                else
                {
                    if (curSum < 0)
                    {
                        // discard and start summing again
                        curSum = 0;
                        sumFlags.SetAll(false);
                    }
                    else
                    {
                        // keep going
                        continue;
                    }
                }
            }

            // output
            Console.WriteLine(maxSum);
        }
    }
}
