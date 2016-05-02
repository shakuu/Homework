using System;
using System.Collections.Generic;
using System.Linq;

namespace _18_Remove_Elements_From_Array
{
    class RemoveElementsFromArrayNOTWORKING
    {
        static void Main()                                          // NOT WORKING 
        {
            //input
            int arraySize = int.Parse(Console.ReadLine());

            // get array
            List<int> toSearch = new List<int>();

            for (int i = 0; i < arraySize; i++)
            {
                toSearch.Add( int.Parse(Console.ReadLine()));
            }

            // variables
            int RemoveCounter = 0;

            // Step 1: Remove Max
            while (!(toSearch[toSearch.Count-1] == toSearch.Max()))     // While Last Element is NOT Last
            {
                toSearch.RemoveAt(toSearch.IndexOf(toSearch.Max()));    // Remove the MAX element
                RemoveCounter++;                                        // increment counter
            }

            // Step 2: Remove Min
            while (!(toSearch[0] == toSearch.Min()))                    // While First Element is NOT First
            {
                toSearch.RemoveAt(toSearch.IndexOf(toSearch.Min()));    // Remove the MIN element
                RemoveCounter++;                                        // increment counter
            }

            // Print the Result
            Console.WriteLine(RemoveCounter);
        }
    }
}
