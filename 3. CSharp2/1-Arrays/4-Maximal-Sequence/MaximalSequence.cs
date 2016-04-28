using System;

namespace _4_Maximal_Sequence
{
    class MaximalSequence
    {
        static void Main()
        {
            //input
            int seqLength = int.Parse(Console.ReadLine());

            //Fill the Array
            int[] numbSeq = new int[seqLength];

            for (int i = 0; i < seqLength; i++)
            {
                numbSeq[i] = int.Parse(Console.ReadLine());
            }

            //Check the Array
            int MaxSeq = 1;
            int currSeq = 1;

            for (int i = 1; i < seqLength; i++)
            {
                if (numbSeq[i] == numbSeq[i-1])
                {
                    currSeq++;      //increment sequence if equal
                }
                else
                {
                    currSeq = 1;    // or reset sequence
                }

                //update max seq if needed
                MaxSeq = currSeq > MaxSeq ?
                    currSeq : MaxSeq;
            }

            //print
            Console.WriteLine(MaxSeq);
        }
    }
}
