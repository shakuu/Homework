using System;
using System.Collections.Generic;

namespace _20_Variatons_Of_Set_With_Same_Number
{
    class VariationsWithSameNumber
    {
        static void Main()      // WORKING, variation of the same element eg 1, 1, 1
        {
            // input
            int arraySize = int.Parse(Console.ReadLine());

            int VariationSize = int.Parse(Console.ReadLine());

            // get the array
            List<int> toSearch = new List<int>();

            for (int i = 1; i < arraySize+1; i++)
            {
                toSearch.Add(i);
            }

            // Using a SECOND list to fill with each 
            // element of the input list
            List<int> curVariation = new List<int>();

            for (int i = 0; i < VariationSize; i++)
            {
                curVariation.Add(0);
            }

            // Recursively Build a sequence
            // with Length -> VariationSize
            GetVariations(toSearch, 0, VariationSize, curVariation);

        }

        public static void GetVariations(List<int> toSearch, int Left, int LengthToBuild, List<int> curVariation)
        {
            // If This is the last element in the squence
            // get all possible variations and return
            if (LengthToBuild == 1)
            {
                // Step 1: Print Variations
                for (int element = 0; element < toSearch.Count; element++)
                {
                    // Fill The last Element of the Variation
                    // with each element of the input array
                    curVariation[Left] = toSearch[element];

                    // Print the current Variation
                    PrintCurrentVariation(curVariation);
                }

                // Step 2: Go back up
                return;
            }

            // OtherWise pick the next element in the sequence 
            // and Send down
            for (int currElement = 0; currElement < toSearch.Count; currElement++)
            {
                // Step 1: Get current Element
                // out of ALL elements
                curVariation[Left] = toSearch[currElement];

                // Step 2: Get The Next Element
                GetVariations(toSearch, Left + 1, LengthToBuild - 1, curVariation);
            }

            return;
        }

        public static void PrintCurrentVariation(List<int> toPrint)
        {
            // Format and Print
            string Print = string.Join(", ", toPrint);

            Console.WriteLine("{" + Print + "}");

            return;
        }
    }
}
