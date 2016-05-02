using System;

namespace _10_N_Factorial
{
    class NFactorial
    {
        static void Main()
        {
            // IMPORTANT: Number stored in reverse order

            // input number N 
            int numberN = int.Parse(Console.ReadLine());

            int[] Number = new int[1] { 1 };    // Factorial - > start with 1

            for (int curMultiplier = 1;          // Start with 1
                     curMultiplier <= numberN;   // Multiply the number 
                     curMultiplier++)            // with each next
            {
                Number = Multiply(Number, curMultiplier);
            }

            // Convert Array Number to Regular number
            string toPrint = ArrayToString(Number);

            // output
            Console.WriteLine(toPrint);
        }

        // Multiply 
        public static int[] Multiply(int[] Number, int Multiplier)
        {
            int curResult = 0;
            int carryOver = 0;

            for (int curDigit = 0;                   // go through  
                     curDigit < Number.Length;       // each digit
                     curDigit++)                     // left to rigght
            {
                curResult = Number[curDigit] *   // multiply 
                            Multiplier +         // and add 
                            carryOver;           // the carryover

                Number[curDigit] = curResult % 10;  // last digit is current digit

                carryOver = curResult / 10;     // next operation carryover
            }

            // append the remaining carryover at the end of the array
            if (carryOver > 0)
            {
                // helper
                int oldNumberSize = Number.Length;

                // Step 1: resize the Array to accomodate the 
                // extra digits 
                Array.Resize(ref Number,
                Number.Length + carryOver.ToString().Length);

                // Step 2: Append
                for (int curDigit = 0;
                         curDigit < carryOver
                                    .ToString()
                                    .Length;
                         curDigit++)
                {
                    Number[oldNumberSize + curDigit] = carryOver % 10;

                    carryOver /= 10;
                }
            }

            // results stored in the same 
            // array
            return Number;
        }

        // Get String to Print
        public static string ArrayToString(int[] Number)
        {
            string toPrint = "";

            for (int curDigit = Number.Length - 1; 
                     curDigit >= 0; 
                     curDigit--)
            {
                toPrint += Number[curDigit].ToString();
            }

            return toPrint;
        }
    }
}
