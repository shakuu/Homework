using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Appearance_Count
{
    class AppearanceCount
    {
        static void Main(string[] args)
        {
            // input
            Console.ReadLine();  // irrelevant, array size input

            // TODO: Alternatively read STRING array
            // compare strings

            // Get the array
            int[] toSearch = Console.ReadLine()            // Read the input
                             .Split(' ')                   // Split by empty space
                             .Select(x => int.Parse(x))    // convert to INT
                             .ToArray();                   // store in an array

            // Get Target Number
            int toFind = int.Parse(Console.ReadLine());

            // output
            Console.WriteLine(ApearanceCount(toSearch, toFind));
        }

        public static int ApearanceCount(int[] toSearch, int toFind)
        {
            // counter
            int AppearanceCounter = 0;

            for (int curElement = 0;                // check each element 
                     curElement < toSearch.Length;  // in the array
                     curElement++)
            {
                if (toSearch[curElement] == toFind) // count each match
                {
                    AppearanceCounter++;
                }
            }

            // return the result
            return AppearanceCounter;
        }
    }
}
