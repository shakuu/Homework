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
            //GET NUMBERS
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

            //FIRST 10
            int[] digits = new int[10];
            for (int i = 0; i < Math.Min(Numbers.Count, 10); i += 2)
            {
                foreach (char currDigit in Numbers[i])
                {
                    if (currDigit != '0')
                    {
                        digits[currDigit - '0']++;
                    }
                }
            }
            //END IF LESS THAN 10
            BigInteger TestResult = 1;

            for (int i = 2; i < 10; i++)
            {
                TestResult = BigInteger.Multiply(TestResult, BigInteger.Pow(i, digits[i]));

            }
            Console.WriteLine(TestResult);
            if (Numbers.Count < 10)
            {
                return;
            }

            //EVERYTHING ELSE
            int[] digits2 = new int[10];
            for (int i = 10; i < Numbers.Count; i += 2)
            {
                foreach (char currDigit in Numbers[i])
                {
                    if (currDigit != '0')
                    {
                        digits2[currDigit - '0']++;
                    }
                }
            }

            BigInteger RESULT10 = 1;
            for (int i = 2; i < 10; i++)
            {
                RESULT10 = BigInteger.Multiply(RESULT10, BigInteger.Pow(i, digits2[i]));
            }
            Console.WriteLine(RESULT10);
        } 
    }
}
      