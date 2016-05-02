using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Subset_With_Sum_S
{
    class SubsetWithSumS
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
                from toStart in Enumerable.Range(0, toSearch.Length)
                from Length in Enumerable.Range(0, toSearch.Length-toStart)

                let SubSets = toSearch.Skip(toStart).Take(Length)

                orderby SubSets.Count() descending

                where SubSets.Sum() == toFindSum

                select SubSets;

            if (currQuery.Count() > 0)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

            // test
            foreach (var item in currQuery.First())
            {
                Console.Write(item + " ");
            }
        }
    }
}
