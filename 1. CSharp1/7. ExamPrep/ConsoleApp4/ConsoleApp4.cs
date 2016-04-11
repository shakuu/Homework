using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleApp4
{
    class ConsoleApp4
    {
        static void Main()
        {
            BigInteger RESULT = 1;
            bool isRunning = true;
            string currNumber = "";

            List<string> Numbers = new List<string>();

            while (isRunning)
            {
                currNumber = Console.ReadLine().ToUpper();
                if (currNumber == "END")
                {
                    isRunning = false;
                }
                else
                {
                    Numbers.Add(currNumber);
                }
            }

            List<BigInteger> toMultiply = new List<BigInteger>();

            for (int i = 0; i < Math.Min(Numbers.Count, 10); i += 2)
            {

                RESULT = 1;
                foreach (char currDigit in Numbers[i])
                {
                    if (currDigit != '0')
                    {
                        RESULT *= (currDigit - '0');
                    }
                }
                toMultiply.Add(RESULT);
            }

            if (Numbers.Count < 10)
            {
                RESULT = 1;
                for (int i = 0; i < toMultiply.Count; i++)
                {
                    RESULT = BigInteger.Multiply(RESULT, toMultiply[i]);
                }
                Console.WriteLine(RESULT);
                return;
            }

            List<BigInteger> toMultiply2 = new List<BigInteger>();
            BigInteger RESULT10 = 1;
            for (int i = 10; i < Numbers.Count; i += 2)
            {

                RESULT10 = 1;
                foreach (char currDigit in Numbers[i])
                {
                    if (currDigit != '0')
                    {
                        RESULT10 *= (currDigit - '0');
                    }
                }
                toMultiply2.Add(RESULT10);
            }

            RESULT = 1;
            for (int i = 0; i < toMultiply.Count; i++)
            {
                RESULT = BigInteger.Multiply(RESULT, toMultiply[i]);
            }
            Console.WriteLine(RESULT);

            RESULT10 = 1;
            for (int i = 0; i < toMultiply2.Count; i++)
            {
                RESULT10 = BigInteger.Multiply(RESULT10, toMultiply2[i]);
            }
            Console.WriteLine(RESULT10);
            
        }


    }
}
