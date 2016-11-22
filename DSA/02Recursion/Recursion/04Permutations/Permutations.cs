using System;
using System.Linq;

namespace _04Permutations
{
    public class Permutations
    {
        static void Main()
        {
            var elementsCount = int.Parse(Console.ReadLine());

            var elements = Enumerable.Range(1, elementsCount).ToArray();
            Permutations.PermutationWrite(elements, 0);
        }

        private static void PermutationWrite(int[] range, int currentIndex)
        {
            if (range.Length <= currentIndex)
            {
                // Full permutation found -> print it.
                Console.WriteLine(string.Join(" ", range));
            }
            else
            {
                // Find the end of the array.
                Permutations.PermutationWrite(range, currentIndex + 1);
                for (int swapWithIndex = currentIndex + 1; swapWithIndex < range.Length; swapWithIndex++)
                {
                    // Swap the current element with each of the element following it.
                    Permutations.SwapElements(range, currentIndex, swapWithIndex);

                    // Find each of the permutation for the current configuration.
                    Permutations.PermutationWrite(range, currentIndex + 1);

                    // Swap the elements back.
                    Permutations.SwapElements(range, currentIndex, swapWithIndex);
                }
            }
        }

        private static void SwapElements(int[] range, int indexA, int indexB)
        {
            range[indexA] ^= range[indexB];
            range[indexB] ^= range[indexA];
            range[indexA] ^= range[indexB];
        }
    }
}
