using System;
using System.Collections.Generic;

namespace _20_Variations_Of_Set
{
    class VariationsOfSetNOT
    {
        static void Main()  // NOT WORKING, variations of UNIQUE elements
        {
            // input
            int arraySize = int.Parse(Console.ReadLine());

            int VariationSize = int.Parse(Console.ReadLine());

            // get the array
            List<int> toSearch = new List<int>();

            for (int i = 0; i < arraySize; i++)
            {
                toSearch.Add(i);
            }

            // Recursively Build a sequence
            // with Length -> VariationSize
            GetVariations(toSearch, 0, VariationSize);

        }

        public static void GetVariations(List<int> toSearch, int Left, int LengthToBuild)
        {
            // If This is the last element in the squence
            // get all possible variations and return
            if (LengthToBuild==1)     
            {
                // Step 1: Print Variations
                for (int position = Left; position < toSearch.Count; position++)
                {
                    // Step 1: Print Current
                    PrintCurrentVariation(toSearch, Left);

                    // Step 2: Shuffle
                    toSearch.Insert(Left, toSearch[toSearch.Count - 1]);
                    toSearch.RemoveAt(toSearch.Count - 1);
                }

                Console.WriteLine("variation");

                // Step 2: Go back up
                return;
            }

            // OtherWise pick the next element in the sequence 
            // and Send down
            for (int currElement = 0; currElement < toSearch.Count; currElement++)
            {
                // Step 1: Get Variatopms
                GetVariations(toSearch, Left + 1, LengthToBuild-1);

                // Step 2: Shuffle
                // last element goes first
                toSearch.Insert(Left, toSearch[toSearch.Count - 1]);
                toSearch.RemoveAt(toSearch.Count - 1);
            }

            return;
        }

        public static void PrintCurrentVariation(List<int> toPrint, int Left)
        {
            // Current Variaton 0 to <= Left 
            List<int> curVariation = new List<int>();

            for (int index = 0; index <= Left; index++)
            {
                curVariation.Add(toPrint[index]);
            }

            string Print = string.Join(", ", curVariation);

            Console.WriteLine("{" + Print + "}");

            return;
        }
    }
}
