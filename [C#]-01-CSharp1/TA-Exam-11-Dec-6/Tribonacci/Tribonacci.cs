using System;
using System.Numerics;

namespace Tribonacci
{
    class Tribonacci
    {
        static void Main()
        {
            //input
            BigInteger num1 = BigInteger.Parse(Console.ReadLine());
            BigInteger num2 = BigInteger.Parse(Console.ReadLine());
            BigInteger num3 = BigInteger.Parse(Console.ReadLine());
            int numN = int.Parse(Console.ReadLine());

            // in case of N: 1 - 3 
            if (numN==1)
            {
                Console.WriteLine(num1);
                return;
            }
            if (numN == 2)
            {
                Console.WriteLine(num2);
                return;
            }
            if (numN == 3)
            {
                Console.WriteLine(num3);
                return;
            }

            // tribonacci Nth number
            BigInteger num4 = 0;

            //calculate numbers 1-3 as input , calculate 4 - N ( 3 - N-1)
            for (int number = 3; number < numN; number++)
            {
                //calculate new number
                num4 = num1 + num2 + num3;

                // shift numbers back
                num1 = num2;
                num2 = num3;
                num3 = num4;
            }

            //print output
            Console.WriteLine(num4);
        }
    }
}
