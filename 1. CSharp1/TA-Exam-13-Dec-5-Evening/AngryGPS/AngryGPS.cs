using System;
using System.Numerics;

namespace AngryGPS
{
    class AngryGPS
    {
        static void Main()
        {
            // input - long by definition
            string inputNum = Console.ReadLine();

            if (inputNum.Contains("-"));
            {
                inputNum = inputNum.TrimStart('-');
            }

            // variables
            BigInteger sumOdd = 0;
            BigInteger sumEven = 0;

            // read each digit and sum odd and even
            for (int digit = 0; digit < inputNum.Length; digit++)
            {
                if ((inputNum[digit] - '0') % 2 == 0)
                {
                    sumEven += inputNum[digit] - '0';
                }
                else
                {
                    sumOdd += inputNum[digit] - '0';
                }
            }

            // to Print :
            //compare sum even to sum odd  
            if (sumEven > sumOdd)
            {
                Console.WriteLine("right {0}", sumEven);
            }
            else if (sumEven < sumOdd)
            {
                Console.WriteLine("left {0}", sumOdd);
            }
            else
            {
                Console.WriteLine("straight {0}", sumEven);
            }
        }
    }
}
