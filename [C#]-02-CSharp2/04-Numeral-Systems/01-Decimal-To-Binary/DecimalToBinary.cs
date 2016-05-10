using System;
using System.Numerics;

namespace _01_Decimal_To_Binary
{
    class DecimalToBinary
    {
        static void Main()
        {
            // TODO: RUNTIME ERROR

            // input -> decimal number
            BigInteger DecNumber = BigInteger.Parse(Console.ReadLine());

            // output 
            string BinNumber = "";
            int toBase = 2;

            while (DecNumber > 0)
            {
                // Step 1: Remainder of Number / toBase 
                // builds the new number Right to Left 
                BinNumber = (DecNumber % toBase).ToString() + BinNumber; 

                // Step 2: divide the number by Base
                DecNumber /= toBase;
            }

            // print the output
            Console.WriteLine(BinNumber);
        }
    }
}
