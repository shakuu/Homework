using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Find_Sum_In_Array
{
    class FindSumInArray
    {
        static void Main()
        {
            // Get Sum 
            int inputSum = int.Parse(Console.ReadLine());

            // standard input format = size + fill array
            int sizeN = int.Parse(Console.ReadLine());

            //Get Array
            int[] inputArray = new int[sizeN];

            for (int i = 0; i < sizeN; i++)
            {
                inputArray[i] = int.Parse(Console.ReadLine());
            }

            // Get sub sequences
            var findTheSum =

                // Divide into subsequences !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                from startAt in Enumerable.Range(0, inputArray.Length)
                from length in Enumerable.Range(1, inputArray.Length-startAt)
               
                let SubSequence = inputArray.Skip(startAt).Take(length)
                // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                orderby SubSequence.Count() descending
                //filter
                where SubSequence.Sum() == inputSum
                //return subsequences
                select SubSequence;

            var ResultSubseq = findTheSum.First();


            foreach (var value in ResultSubseq)
            {
                Console.Write(value.ToString() + " ");
            }

            Console.Write(ResultSubseq.Sum());

        }
    }
}
