using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Maximal_Sum
{
    class MaximalSum
    {
        static void Main()
        {

            //input
            int sizeN = int.Parse(Console.ReadLine());

            //get numbers
            List<int> numSequence = new List<int>();

            for (int i = 0; i < sizeN; i++)
            {
                numSequence.Add(int.Parse(Console.ReadLine()));
            }

            //SORT Numbers

            var subSeq =
                //Select all possible subsequence starting indices:
                from StartPos in Enumerable.Range(0, numSequence.Count)

                //Select all possible lengths of subsequences given the starting index:  
                from Length in Enumerable.Range(1, numSequence.Count - StartPos)

                //Extract the subsequence from the array
                let subseq = numSequence.Skip(StartPos).Take(Length)
                
                //Order subsequences by descending length(i.e.longest first)
                orderby subseq.Count() descending

                //Calculate the sum of each subsequence and order the subsequences so highest valued sums are first:
                orderby subseq.Sum() descending
                
                //Select the subsequences:
                select subseq;

            var maxSumSubseq = subSeq.First();

            Console.WriteLine(maxSumSubseq.Sum());
        }
    }
}
