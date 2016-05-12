using System;
using System.Numerics;

namespace _07_One_Base_To_Any_Other
{
    class AnyToAny
    {
        static void Main()
        {
            // TODO: 85/ 100

            // input 
            int fromBase = int.Parse(Console.ReadLine());

            string toConvert = Console.ReadLine().ToUpper();

            int toBase = int.Parse(Console.ReadLine());

            // variables 
            string[] HexKey = "0 1 2 3 4 5 6 7 8 9 A B C D E F".Split(' ');

            string Result = "";

            // Step 1: to Dec
            Result = AnyToDec(toConvert, fromBase, HexKey);

            // Step 2: to Any
            Result = DecToAny(Result, toBase, HexKey);

            if (Result == "")
            {
                Result = "0";
            }

            Console.WriteLine(Result.ToUpper().TrimStart('0'));
        }

        // Step 1: Any to Decimal
        public static string AnyToDec(string toConvert, int fromBase, string[] Key)
        {
            BigInteger Sum = 0;

            for (int curIndex = 0; curIndex < toConvert.Length; curIndex++)
            {
                // base ^ index ( right to left ) * value of the digit
                Sum += (BigInteger)Math.Pow(fromBase, curIndex)
                    * Array.IndexOf(Key, toConvert[toConvert.Length - 1 - curIndex].ToString());
            }

            return Sum.ToString();
        }

        // Step 2: Decimal to Any
        public static string DecToAny(string toConvert, int toBase, string[] Key)
        {
            BigInteger DecNumber = BigInteger.Parse(toConvert);

            string NewNumber = "";

            while (DecNumber > 0)
            {
                // remainders build the new digit right to left
                NewNumber = Key[(int)(DecNumber % toBase)] + NewNumber;

                // divide by base
                DecNumber /= toBase;
            }

            return NewNumber;
        }
    }
}
