using System;
using System.Linq;

namespace _9_Frequent_Number
{
    class FrequentNumber
    {
        static void Main()
        {
            //input
            int SizeN = int.Parse(Console.ReadLine());

            int[] arrayA = new int[SizeN];

            //get array
            for (int i = 0; i < SizeN; i++)
            {
                arrayA[i] = int.Parse(Console.ReadLine());
            }

            // Get the most freqent number

            var LookForNum =
                // from numbers in array
                from num in arrayA
                //group the numbers by value in groups
                group num by num into groups
                //sort the groups by length
                orderby groups.Count() descending
                // return groups
                select groups;

            var MostCommon = LookForNum.First();

            Console.WriteLine("{0} ({1} times)", MostCommon.Key, MostCommon.Count());
        }
    }
}
