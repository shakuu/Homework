using System;
using System.Linq;

namespace _17_Subset_K_With_Sum_S
{
    class SubsetKwithSumS
    {
        static void Main()
        {
            // input
            int arraySize = int.Parse(Console.ReadLine());

            // get array
            int[] toSearch = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSearch[i] = int.Parse(Console.ReadLine());
            }

            // get SUM
            int toFindSum = int.Parse(Console.ReadLine());

            // get Subset size
            int toFindSubsetLen = int.Parse(Console.ReadLine());

            int PowerSetSize = 1 << arraySize;  // equiavalent to Math.Pow(2, arraySize)

            var PowerSet =                                                       // each subset contains a set of array elements
                from PowerSetIndex in Enumerable.Range(0, PowerSetSize)          // for each new PowerSet Subset 
                select                                                           // Return Elements 
                    from ArrayIndex in Enumerable.Range(0, toSearch.Count())     // From the input Array toSearch
                        where (PowerSetIndex & (1 << ArrayIndex)) != 0           // If PowerSet Index and ArrayIndex 
                    select toSearch[ArrayIndex];                                 // have a matching bit return that Element

            // Find Subsets with Matching Sum 
            PowerSet =
                from SubSet in PowerSet                     // for each existing subset in PowerSet

                where SubSet.Sum() == toFindSum             // return if sum == toFindSUM
                   && SubSet.Count() == toFindSubsetLen     // AND Count == required Length

                select SubSet;                              // Returb the subsets

            if (PowerSet.Count() > 0)
            {
                Console.WriteLine("yes");
            }

            // TEST
            Console.Write(string.Join("\n", PowerSet.Select(        // For each subset, separated by NewLine
                            subset => string.Join(" ", subset))));  // join it s sub elements in a string
        }
    }
}
