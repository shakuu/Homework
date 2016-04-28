using System;
using System.Collections;

namespace _6_Maximal_K_Sum
{
    class Program
    {

        public class myCompare : IComparer
        {
            int IComparer.Compare(object Two, object One)
            {
                int intTwo = (int)Two;
                int intOne = (int)One;

                if (intOne == 3)
                {
                    return -1; // -1 switch them // 1 leave them // 0 do nothing
                }
                //else if (intTwo == 3)
                //{
                //    return 1;
                //}
                else
                {
                    return 0;
                }
            }
        }



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

            myCompare comp = new myCompare();

            //sort the array
            Array.Sort(arrayA, comp);

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
