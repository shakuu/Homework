using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Merge_Sort
{
    class MergeSort
    {
        static void Main()
        {
            //input
            int arraySize = int.Parse(Console.ReadLine());

            // get array
            int[] toSort = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSort[i] = int.Parse(Console.ReadLine());
            }

            //variables
            int arrayMid = (arraySize - 1) / 2;
            int arrayLeft = 0;

            DivideLeft(toSort, arrayLeft, arrayMid, arraySize);
        }

        public static void DivideLeft(int[] ArrToSort, int LeftPint, int MidPoint, int Size)
        {

            //Step 1: Return if Split to 1 element
            if (MidPoint <= 1)
            {
                return;
            }

            // Step 2: Find the new Midpoint
            int newMid = MidPoint / 2;
            int newSize = MidPoint;

            // Step 3: Divide Again 
            // Left 
            DivideLeft(ArrToSort, 0, newMid, newSize);
            DivideLeft(ArrToSort, newMid, newMid + (MidPoint - newMid) / 2, MidPoint);
            //Right

            //Step 4: Merge


        }

        public static void MergeLeft(int[] ArrToSort, int Left, int Right)
        {
            for (int i = Left; i < Right; i++)
            {

            }
        }
    }
}
