using System;

namespace _05_Max_Increasing_Sequence_New
{
    class MaxIncreasingSeq
    {
        static void Main()
        {
            //input
            int arraySize = int.Parse(Console.ReadLine());

            // get array
            int[] toSearch = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSearch[i] = int.Parse(Console.ReadLine());
            }

            // For each element, search how many elements 
            // after it are larger 

            // variables
            int curSequence = 1;
            int maxSequence = 0;
            int curNumberToCheck = 0;

            // for each number
            for (int curNumber = 0; 
                     curNumber < toSearch.Length; 
                     curNumber++)
            {
                //reset
                curSequence = 1;
                curNumberToCheck = toSearch[curNumber];

                // check hte numbers after
                for (int nextNumber = curNumber + 1; 
                         nextNumber < toSearch.Length; 
                         nextNumber++)
                {
                    if (toSearch[nextNumber] > curNumberToCheck)
                    {
                        curSequence++;
                        //curNumberToCheck = toSearch[nextNumber];
                    }
                }

                // check if current sequence is largest
                if (curSequence>maxSequence)
                {
                    maxSequence = curSequence;
                }
            }

            Console.WriteLine(maxSequence);
        }
    }
}
