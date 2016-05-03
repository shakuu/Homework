using System;
using System.Numerics;

namespace _04_Hexadecimal_To_Decimal
{
    class HexToDec
    {
        static void Main()
        {
            // input
            string HexNumber = Console.ReadLine().ToUpper();

            // variables
            // can be used for ANY base up to 16
            string[] HexKey = "0 1 2 3 4 5 6 7 8 9 A B C D E F".Split(' ');

            int fromBase = 16;

            BigInteger DecNumber = 0;

            for (int curIndex = 0; 
                     curIndex < HexNumber.Length; 
                     curIndex++)
            {
                DecNumber += (BigInteger)Math.Pow(fromBase, curIndex)
                           * Array.IndexOf(HexKey,
                             HexNumber[HexNumber.Length - 1 - curIndex].ToString());         
            }

            //print
            Console.WriteLine(DecNumber.ToString());
        }
    }
}
