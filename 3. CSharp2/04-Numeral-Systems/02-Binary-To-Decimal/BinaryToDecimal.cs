using System;
using System.Numerics;

namespace _02_Binary_To_Decimal
{
    class BinaryToDecimal
    {
        static void Main()
        {
            // input Bin Number
            string BinNumber = Console.ReadLine();

            BigInteger DecNumber = 0;

            //helper
            int fromBase = 2;

            // Read the string right to left
            for (int curDigit = 0;
                     curDigit < BinNumber.Length;
                     curDigit++)
            {
                // CurrentDigit * Base ^ Index
                DecNumber += (int)Math.Pow(fromBase, curDigit) * 
                    int.Parse(BinNumber[BinNumber.Length-1-curDigit].ToString());
            }

            Console.WriteLine(DecNumber.ToString());
        }
    }
}
