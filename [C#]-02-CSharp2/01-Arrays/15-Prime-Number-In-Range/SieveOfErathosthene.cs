using System;
using System.Collections.Generic;
using System.Linq;

namespace _15_Prime_Number_In_Range
{
    class SieveOfErathosthene
    {
        static void Main()
        {
            // input Range N 
            int Range = int.Parse(Console.ReadLine());

            // List of Odd Numbers
            List<int> ListOfPrimes = new List<int>();
            ListOfPrimes.Add(0);
            ListOfPrimes.Add(1);
            ListOfPrimes.Add(2);

            // generate a list
            for (int i = 3; i <= Range; i+=2)
            {
                ListOfPrimes.Add(i);
            }
            
            // Variables
            int currStep = 3;
            int currStepIndex = 3;

            while (true)
            {
                if (currStep * currStep > Range)
                {
                    break;
                }

                // Each element
                for (int index = currStepIndex + 1; index < ListOfPrimes.Count; index++)
                {
                    // check if it can be divided by the current step
                    if (ListOfPrimes[index] % currStep == 0)
                    {
                        // if YES .. remove it , NOT Prime
                        ListOfPrimes.RemoveAt(index);
                        index--;
                    }
                }

                // increment within the range of the List
                if (!(currStepIndex + 1 >= ListOfPrimes.Count))
                {
                    currStepIndex++;
                }
                else
                {
                    break;
                }

                // increment the step
                currStep = ListOfPrimes[currStepIndex];
            }

            Console.WriteLine(ListOfPrimes.Last());
        }
    }
}
