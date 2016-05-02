using System;
using System.Collections;

namespace _6_Maximal_K_Sum
{
    class MaxKSum
    {
        static void Main()
        {
            //input
            int arraySize = int.Parse(Console.ReadLine());
            int numbK = int.Parse(Console.ReadLine());


            // get the array		numbK	3	int

            int[] arrayA = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                arrayA[i] = int.Parse(Console.ReadLine());
            }

            //sort the array
            Array.Sort(arrayA);

            // get the sum
            int maxSum = 0;

            for (int i = 0; i < numbK; i++)
            {
                maxSum += arrayA[arrayA.Length - 1 - i];
            }

            //print
            Console.WriteLine(maxSum);
        }
    }
}
