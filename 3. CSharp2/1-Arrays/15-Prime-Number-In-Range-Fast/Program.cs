using System;
using System.Collections.Generic;
using System.Linq;

namespace _15_Prime_Number_In_Range_Fast
{
    class SieveOfErathosthene
    {
        static void Main()
        {
            // input Range N 
            int Range = int.Parse(Console.ReadLine());

            // List of Odd Numbers
            List<int> ListOfPrimes = Enumerable.Range(0, Range + 1).ToList();
            List<int> Flags = Enumerable.Range(0, Range + 1).Select(num => num * 0).ToList();
            
            // Variables
            int currStep = 2;

            while (true)
            {
                // stop if square of current step is larger than range
                if (currStep * currStep > Range)
                {
                    break;
                }

                // Each element
                for (int i = currStep * currStep; i < ListOfPrimes.Count; i+= currStep)
                {
                    Flags[i] = 1;
                }

                // find the next unflagged number
                for (int i = currStep+1; i < ListOfPrimes.Count; i++)
                {
                    if (Flags[i] == 0)
                    {
                        currStep = ListOfPrimes[i];
                        break;
                    }
                }
            }

            // Find the First Unflagged Number
            int toPrint = -1;

            for (int i = ListOfPrimes.Count-1; i >= 0; i--)
            {
                if (Flags[i] == 0)
                {
                    toPrint = ListOfPrimes[i];
                    break;
                }
            }
            
            Console.WriteLine(toPrint);
        }
    }
}
