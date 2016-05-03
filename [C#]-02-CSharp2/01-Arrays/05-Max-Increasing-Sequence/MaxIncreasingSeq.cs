using System;

namespace _5_Maximal_Incresing_Sequence
{
    class MaximalSequence
    {
        static void Main()
        {
            // TODO: 0/ 100 BGCODER

            //input
            long seqLength = long.Parse(Console.ReadLine());

            //Fill the Array
            long[] numbSeq = new long[seqLength];

            for (int i = 0; i < seqLength; i++)
            {
                numbSeq[i] = long.Parse(Console.ReadLine());
            }

            //Check the Array
            int MaxSeq = 1;
            int currSeq = 1;
            //long curSeqSum = 0;
            //long MaxSum = long.MinValue;

            //int Increment = 1;

            for (int i = 1; i < seqLength; i++)
            {
                if (numbSeq[i] >= numbSeq[i - 1])  // increment
                {
                    currSeq++;      //increment sequence if equal
                    //curSeqSum += numbSeq[i];
                }
                else
                {
                    currSeq = 1;    // or reset sequence
                    //curSeqSum = 0;
                }

                //update max seq if needed
                MaxSeq = currSeq > MaxSeq ?
                    currSeq : MaxSeq;
                //if (curSeqSum > MaxSum)
                //{
                //    MaxSum = curSeqSum;
                //    MaxSeq = currSeq;
                //}
            }

            //print
            Console.WriteLine(MaxSeq);
        }
    }
}
