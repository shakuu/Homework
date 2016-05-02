using System;
using System.Linq;

namespace _02_Get_Largest_Number
{
    class GetLargestNumber
    {
        static void Main()
        {
            // input
            int[] inputNumbers = Console.ReadLine()           // Read the string
                                 .Split(' ')                  // split the string
                                 .Select(x => int.Parse(x))   // convert to in
                                 .ToArray();                  // to array

            // variables
            int MaxNumber = int.MinValue;

            //check for each element
            for (int curElement = 0;
                     curElement < inputNumbers.Length;
                     curElement++)
            {
                MaxNumber = GetMax(                      // compare  
                            MaxNumber,                   // current max
                            inputNumbers[curElement]);   // with current input number
            }

            // Print the Largest number
            Console.WriteLine(MaxNumber);
        }

        // Get Max out of 2 input numbers
        public static int GetMax(int numA, int numB)
        {
            if (numA >= numB)   // if 1st number
            {                   // is larger or equal
                return numA;    // reutrn 1st number
            }                   //
            else                //
            {                   //
                return numB;    //
            }
        }
    }
}
