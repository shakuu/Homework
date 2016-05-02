using System;
using System.Linq;

namespace _06_First_Larger_Than_Neighbour
{
    class FirstlargerThanNeighbour
    {
        static void Main()
        {
            // TODO: DO WITH BINARY SEARCH

            //input
            Console.ReadLine(); // array size, irrelevant

            // get array
            int[] toSearch = Console.ReadLine()
                             .Trim(' ')
                             .Split(' ')
                             .Select(curElement => int.Parse(curElement))
                             .ToArray();

            for (int curElement = 1;
                     curElement < toSearch.Length - 1;
                     curElement++)
            {
                if (isLargerThanNeighbours(
                    toSearch[curElement],
                    toSearch[curElement - 1],
                    toSearch[curElement + 1]))
                {
                    Console.WriteLine(curElement);
                    return;
                }
            }

            // if match not found -1
            Console.WriteLine("-1");
        }

        public static bool isLargerThanNeighbours(
                      int curElement,
                      int prevElement,
                      int nextElement)
        {
            if (curElement > prevElement && 
                curElement > nextElement)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
