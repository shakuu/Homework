using System;
using System.Collections.Generic;

namespace _18_Remove_Elements_From_Array_Correct
{
    class Program
    {
        static void Main()      // TODO: Counter LEFT == Counter Right 
        {                       // seems one is unnecessary
            //input
            int arraySize = int.Parse(Console.ReadLine());

            // get array
            List<int> toSearch = new List<int>();

            for (int i = 0; i < arraySize; i++)
            {
                toSearch.Add(int.Parse(Console.ReadLine()));
            }

            // variables
            int RemoveCounterLeft = 0;
            int RemoveCounterRight = 0;

            // Left To right
            for (int i = 0; i < arraySize - 1; i++)
            {
                if (toSearch[i] > toSearch[i + 1])  // If Larger than the next in line 
                {
                    RemoveCounterLeft++;            // Remove it
                }
            }

            // Right To Left
            for (int i = arraySize - 1; i > 0; i--)
            {
                if (toSearch[i] < toSearch[i-1])    // if smaller than the previous in line
                {
                    RemoveCounterRight++;           // remove it
                }
            }

            // PRINT
            Console.WriteLine(Math.Min(RemoveCounterLeft, RemoveCounterRight));
        }
    }
}
