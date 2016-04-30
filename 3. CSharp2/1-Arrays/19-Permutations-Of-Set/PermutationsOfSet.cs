using System;
using System.Collections.Generic;

namespace _19_Permutations_Of_Set
{
    class PermutationsOfSet
    {
        static void Main()  // TODO: WORK IN PROGRESS 
        {
            // input
            int arraySize = int.Parse(Console.ReadLine());

            // get array
            List<int> toSearch = new List<int>();

            for (int i = 0; i < arraySize; i++)
            {
                toSearch.Add(int.Parse(Console.ReadLine()));
            }

            // GET PERMUTATIONS

            // NOT NECESSARY
            //// Step 1: Number of Permutations = factorial of the length
            //int NumberOfPermutations = 1;

            //for (int elementNumber = 0;
            //         elementNumber <= arraySize;
            //         elementNumber++)
            //{
            //    NumberOfPermutations += elementNumber;
            //}

            // TODO: IF array has less than TWO elements
            // print the number and close
            if (toSearch.Count==1)
            {
                Console.WriteLine(toSearch[0]);
                return;
            }
            else if (toSearch.Count == 0)
            {
                return;
            }

            // Step 2: Generate the Permutations
            // Recursive
            Permutate(toSearch, 0, arraySize - 1);

        }

        // Recursive Permutation
        public static void Permutate(List<int> toSearch, int Left, int Right)
        {
            // If the current section has 3 elements
            // Permutate them 
            if (Right - Left == 1)
            {
                for (int i = 0; i <= Right-Left; i++)
                {
                    // Step 1: Print theList
                    PrintTheList(toSearch);

                    // Step 2: Switch the 2 elements
                    toSearch[Left] ^= toSearch[Right];
                    toSearch[Right] ^= toSearch[Left];
                    toSearch[Left] ^= toSearch[Right];
                }

                // Job's done
                return;
            }

            // Otherwise, shuffle the elements
            // and pass along for permutation
            for (int curPermutation = 0;
                     curPermutation <= Right - Left;
                     curPermutation++)
            {
                // Step 1: Permutate the current section
                // less one element
                Permutate(toSearch, Left + 1, Right);

                // Step 2: Rearrange Elements
                // Last Element goes first 
                // withing the current section
                toSearch.Insert(Left, toSearch[toSearch.Count - 1]);
                toSearch.RemoveAt(toSearch.Count - 1);
            }

            // NOT NECESSARY
            // Step 3: Elements back in their original order
            //toSearch.Insert(Left, toSearch[toSearch.Count - 1]);
            //toSearch.RemoveAt(toSearch.Count - 1);

            // All permutations should be printed
            return;
        }

        public static void PrintTheList(List<int> toPrint)
        {
            // {1, 2, 3, 4, 5}
            string currString = string.Join(", ", toPrint);

            Console.WriteLine("{" + currString + "}");

            return;
        }
    }
}
