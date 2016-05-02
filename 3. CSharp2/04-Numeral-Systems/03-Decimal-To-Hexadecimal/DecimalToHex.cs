using System;

namespace _03_Decimal_To_Hexadecimal
{
    class DecimalToHex
    {
        static void Main()
        {
            //input
            int DecNumber = int.Parse(Console.ReadLine());

            // variablse
            string HexNumber = "";
            string[] HexKey = "0 1 2 3 4 5 6 7 8 9 A B C D E F".Split(' ');

            int toBase = 16;

            while (DecNumber > 0)
            {
                // Step 1: Remainders build the Hex number
                // Right To Left
                HexNumber = HexKey[DecNumber % toBase]
                          + HexNumber;

                // Step 2: Divide the Dec Number by toBase
                DecNumber /= toBase;
            }

            // print
            Console.WriteLine(HexNumber);
        }
    }
}
