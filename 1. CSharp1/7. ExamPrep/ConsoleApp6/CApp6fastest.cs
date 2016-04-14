using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleApp2
{
    class ConsoleApp6
    {
        static void Main()
        {
            BigInteger RESULT = 1;
            bool isRunning = true;
            string currNumber = "";

            //GET NUMBERS <10
            int[] digits1 = new int[10];
            int inputCounter = 0;
            while (isRunning)
            {
                currNumber = Console.ReadLine().ToUpper();
                if (currNumber == "END")
                {
                    isRunning = false;
                    break;
                }
                else
                {
                    foreach (char currDigit in currNumber)
                    {
                        if (currDigit != '0')
                        {
                            digits1[currDigit - '0']++;
                        }
                    }
                    inputCounter++;
                }
                currNumber = Console.ReadLine().ToUpper();
                inputCounter++;
                if (currNumber == "END")
                {
                    isRunning = false;
                    break;
                }

                //end on 10
                if (inputCounter == 10)
                {
                    break;
                }
            }
            //EVERYTHING ELSE
            int[] digits2 = new int[10];
            while (isRunning)
            {
                currNumber = Console.ReadLine().ToUpper();
                if (currNumber == "END")
                {
                    isRunning = false;
                    break;
                }
                else
                {
                    foreach (char currDigit in currNumber)
                    {
                        if (currDigit != '0')
                        {
                            if (currDigit == '4')
                            { digits2[2] += 2; }
                            else if ( currDigit=='8')
                            { digits2[2] += 3; }
                            else
                            { digits2[currDigit - '0']++; }
                        }
                    }
                }
                currNumber = Console.ReadLine().ToUpper();
                if (currNumber == "END")
                {
                    isRunning = false;
                    break;
                }
            }

            
            BigInteger TestResult = 1;
            for (int i = 2; i < 10; i++)
            {
                TestResult = BigInteger.Multiply(TestResult, BigInteger.Pow(i, digits1[i]));

            }
            
            Console.WriteLine(TestResult);
            if ( inputCounter < 10)
            { return; }
            
            BigInteger RESULT10 = 1;
            for (int i = 2; i < 10; i++)
            {
                RESULT10 = BigInteger.Multiply(RESULT10, BigInteger.Pow(i, digits2[i]));
            }
           
            Console.WriteLine(RESULT10);
        }
    }
}
