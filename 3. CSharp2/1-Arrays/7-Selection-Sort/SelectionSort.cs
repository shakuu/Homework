using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Selection_Sort
{
    class SelectionSort
    {
        static void Main()
        {
            //input
            int sizeN = int.Parse(Console.ReadLine());

            //get array
            int[] arrayA = new int[sizeN];

            for (int i = 0; i < sizeN; i++)
            {
                arrayA[i] = int.Parse(Console.ReadLine());
            }

            //SORT
            //each element to 2nd last
            for (int current = 0; current < sizeN-1; current++)
            {
                //compare with each next element in the array
                //smaller element moves left
                for (int next = current+1; next < sizeN; next++)
                {
                    if (arrayA[current]>arrayA[next])
                    {
                        arrayA[current] ^= arrayA[next];    // a = a ^ b 
                        arrayA[next] ^= arrayA[current];    // b = (a ^ b) ^ b -> a
                        arrayA[current] ^= arrayA[next];    // a = (a ^ b) ^ a -> b
                    }
                }
            }

            //output
            for (int i = 0; i < sizeN; i++)
            {
                Console.WriteLine(arrayA[i]);
            }
        }
    }
}
