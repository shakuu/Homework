using System;
using System.Linq;

namespace _05_Larger_Than_Neighbours
{
    class LargerThanNeighbours
    {
        static void Main()
        {
            // input
            Console.ReadLine(); // array size, not needed

            // Get the Array
            int[] toSearch = Console.ReadLine()          // Read Input string
                             .Trim(' ')
                             .Split(' ')                 // Split
                             .Select(x => int.Parse(x))  // Convert to INT
                             .ToArray();                 // Store in Array

            // variables
            int foundCounter = 0;

            // Assuming FIRST and LAST do NOT have Neightbours
            for (int curElement = 1;                    // Search Array starting at 2nd element
                     curElement < toSearch.Length - 1;  // up to 2nd last element
                     curElement++)                      // assuming 1st and last element 
            {                                           // do NOT have 2 neighbours in the first place
                if (isLargerThanNeighbours(             // Call Check with 3 numbers
                        toSearch[curElement],           // current
                        toSearch[curElement - 1],       // previous
                        toSearch[curElement + 1]))      // next
                {
                    foundCounter++;
                }
            }

            // TODO: First and Last element cases
            // Should not be needed by definition
            //if (toSearch[0] > 
            //    toSearch[1])
            //{
            //    foundCounter++;
            //}

            //if (toSearch[toSearch.Length - 1] > 
            //    toSearch[toSearch.Length - 2])
            //{
            //    foundCounter++;
            //}

            // output
            Console.WriteLine(foundCounter);
        }

        public static bool isLargerThanNeighbours(  // Take 3 Numbers as input
                      int curNumber,                // current number to check
                      int prevNumber,               // previous number in the array
                      int nextNumber)               // next number in the array
        {
            if (curNumber > prevNumber &&   // current number needs to be           
                curNumber > nextNumber)     // larger than its neighbours
            {                               //
                return true;                // return TRUE if so
            }                               //
            else                            //
            {                               //
                return false;               // or FALSE if not 
            }
        }
    }
}
