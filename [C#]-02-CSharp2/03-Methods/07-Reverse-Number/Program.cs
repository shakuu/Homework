using System;

namespace _07_Reverse_Number
{
    class Program
    {
        static void Main()
        {
            // TODO: Case Negative

            //input
            string toReverse = Console.ReadLine();

            // variables
            bool isNegative = false;

            // Check for negative
            if (toReverse.Contains("-"))
            {
                isNegative = true;

                toReverse = toReverse.Remove('-');
            }

            // output
            if (!isNegative)
            {
                Console.WriteLine(GetReverse(toReverse));
            }
            else
            {
                Console.WriteLine("-" + GetReverse(toReverse));
            }

        }

        public static string GetReverse(string toReverse)
        {
            // store the reversed string
            string ReversedInput = "";

            for (int curDigit = toReverse.Length - 1;   // Read input
                     curDigit >= 0;                     // Last to First
                     curDigit--)                        //
            {
                ReversedInput += toReverse[curDigit];   // write in a new string
            }
            // return the new , reversed string
            return ReversedInput;
        }
    }
}
