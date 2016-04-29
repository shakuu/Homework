using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_Permutations_Of_Set
{
    class PermutationsOfSet
    {
        static void Main()  // TODO: WORK IN PROGRESS
        {
            // input
            int arraySize = int.Parse(Console.ReadLine());

            // get array
            int[] toSearch = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSearch[i] = int.Parse(Console.ReadLine());
            }

            // GET PERMUTATIONS

            // Step 1: Number of Permutations = factorial of the length
            int NumberOfPermutations = 1;

            for (int elementNumber = 0; 
                     elementNumber <= arraySize; 
                     elementNumber++)
            {
                NumberOfPermutations += elementNumber;
            }

            // Step 2: Generate the Permutations
           
        }
    }
}
