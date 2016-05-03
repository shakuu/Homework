using System;

namespace _05_Max_Increasing_Sequence_CheckWithFirst
{
    class Program
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
            for (int curNumber = 1;
                     curNumber < toSearch.Length;
                     curNumber++)
            {
                //reset
                curSequence = 1;
                curNumberToCheck = toSearch[curNumber];

                //if current element is larger than the one before
                // check the ones after
                if (toSearch[curNumber] >= toSearch[curNumber - 1])
                {
                    curSequence++;

                    // check hte numbers after
                    for (int nextNumber = curNumber + 1;
                             nextNumber < toSearch.Length;
                             nextNumber++)
                    {
                        if (toSearch[nextNumber] >= toSearch[curNumber - 1])
                        {
                            curSequence++;
                            //curNumberToCheck = toSearch[nextNumber];
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                // check if current sequence is largest
                if (curSequence > maxSequence)
                {
                    maxSequence = curSequence;
                }
            }

            Console.WriteLine(maxSequence);
        }
    }
}
