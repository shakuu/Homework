using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Subset_With_Sum_S_Simple
{
    class PowerSetSimple
    {
        static void Main(string[] args)
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

            // get the power set 
            int[] powerSet = new int[arraySize * arraySize];

            //for each subset in the powerset
            for (int Pindex = 0; Pindex < powerSet.Length; Pindex++)
            {
                // check with each element 
                for (int Aindex = 0; Aindex < toSearch.Length; Aindex++)
                {
                    if ((Pindex & (1 << Aindex)) != 0)
                    {
                        powerSet[Pindex] += toSearch[Aindex];
                    }
                }

            }
        }
    }
}
