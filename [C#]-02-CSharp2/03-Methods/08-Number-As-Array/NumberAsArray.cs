using System;
using System.Linq;

namespace _08_Number_As_Array
{
    class NumberAsArray
    {
        static void Main()
        {
            // TODO: 50/ 100

            // input
            Console.ReadLine();     // Input Line 1 : array sizes - not needed

            int[] NumberOne = Console.ReadLine()                    // read input
                              .Trim(' ')                            // trim trailing empty 
                              .Split(' ')                           // split into digits
                              .Select(digit => int.Parse(digit))    // convert to int
                              .ToArray();                           // store in an array

            int[] NumberTwo = Console.ReadLine()                    // read input
                              .Trim(' ')
                              .Split(' ')                           // split into digits
                              .Select(digit => int.Parse(digit))    // convert to int
                              .ToArray();                           // store in an array

            // get the sum
            int[] Result = GetSum(NumberOne, NumberTwo);

            // format the string
            string outputString = string.Join(" ", Result);

            // output
            Console.WriteLine(outputString);
        }

        public static int[] GetSum(int[] NumberOne, int[] NumberTwo)
        {
            int[] Result = new int[Math.Max(                        // Resulting array
                                   NumberOne.Length,                // of size 
                                   NumberTwo.Length)];              // larger of the two

            // helper
            int CarriedOver = 0;
            int curSum = 0;

            for (int curDigit = 0;              // For each element
                     curDigit < Math.Min(       // of the shorter 
                         NumberOne.Length,      // of the two
                         NumberTwo.Length);     // input numbers
                     curDigit++)                //
            {
                curSum = 0;
                curSum = NumberOne[curDigit] +  // 
                         NumberTwo[curDigit] +  // 
                         CarriedOver;

                // reset carried Over after it's applied
                CarriedOver = 0;

                if (curSum > 9)     // one digit only
                {                   // 
                    curSum %= 10;   // get last digit
                    CarriedOver++;  // carry over if larger
                }                   // 

                Result[curDigit] = curSum;
            }

            // TODO: Case numbers have different length
            if (NumberOne.Length > NumberTwo.Length)
            {
                Result = FillEmpty(NumberOne,
                                   NumberTwo,
                                   Result,
                                   CarriedOver);
                CarriedOver = 0;
            }
            else if (NumberOne.Length < NumberTwo.Length)
            {
                Result = FillEmpty(NumberTwo,
                                   NumberOne,
                                   Result,
                                   CarriedOver);
                CarriedOver = 0;
            }

            // In case there's something to carry over 
            // with equal length numbers
            if (CarriedOver > 0)
            {
                Array.Resize(ref Result, Result.Length + 1);
                Result[Result.Length - 1] = CarriedOver;
            }

            return Result;
        }

        // Helper Method
        public static int[] FillEmpty(
                      int[] LongerArray,
                      int[] ShorterArray,
                      int[] Result,
                      int CarriedOver)
        {
            for (int curElement = ShorterArray.Length;
                         curElement < LongerArray.Length;
                         curElement++)
            {
                Result[curElement] = LongerArray[curElement] + CarriedOver;
                CarriedOver = 0;

                if (Result[curElement] > 9)
                {
                    Result[curElement] %= 10;
                    CarriedOver++;
                }
            }

            // If there's something to carry over
            if (CarriedOver > 0)
            {
                Array.Resize(ref Result, Result.Length + 1);
                Result[Result.Length - 1] = CarriedOver;
            }

            return Result;
        }
    }
}
