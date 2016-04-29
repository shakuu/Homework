using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.rosettacode.org/wiki/Power_set#C.23
// Power Set

namespace _16_Subset_With_Sum_S_SET
{
    class PowerSet
    {
        static void Main()      // INCORRECT - subSEQUENCE NOT subSET
        {
            // input
            int arraySize = int.Parse(Console.ReadLine());

            // fill the array
            int[] toSearch = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                toSearch[i] = int.Parse(Console.ReadLine());
            }

            // get the sum
            int toFindSum = int.Parse(Console.ReadLine());

            var currQuery =
                from subsetCount in Enumerable.Range(0, 1<<toSearch.Count()) // 2^count subsets
                    select
                         from numb in Enumerable.Range(0, toSearch.Count()) // each subset containing a subset
                         where (subsetCount & (1 << numb)) != 0             // of individial items ( numbers )
                         select toSearch[numb];

            //Console.Write(string.Join(Environment.NewLine,
            //            currQuery.Select(subset =>
            //                    string.Join(",", subset.Select(clr => clr.ToString()).ToArray())).ToArray()));

            foreach (var item in currQuery)
            {
                if (item.Sum() == toFindSum)
                {
                    Console.WriteLine("yes");
                    break;
                }
            }
        }
    }
}
