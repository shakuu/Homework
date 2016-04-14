using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleApp7
{
    class ConsoleApp7
    {
        static void Main()
        {
            bool isRunning = true;
            string currNumber = "";

            //GET NUMBERS <10
            int[] digits1 = new int[4];
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
                    for ( int c = 0; c < currNumber.Length; c++)
                    {
                        switch (currNumber[c])
                        {
                            case '2':
                                digits1[0]++; //[0] -> 2s
                                break;
                            case '3':
                                digits1[1]++; // [1] -> 3s
                                break;
                            case '4':
                                digits1[0] += 2;
                                break;
                            case '5':
                                digits1[2]++; //[2] -> 5s
                                break;
                            case '6':
                                digits1[0]++;
                                digits1[1]++;
                                break;
                            case '7':
                                digits1[3]++; //[3] ->7s
                                break;
                            case '8':
                                digits1[0]+=3;
                                break;
                            case '9':
                                digits1[1]+=2;
                                break;
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
                    for(int c = 0; c < currNumber.Length; c++)
                    {
                        switch (currNumber[c])
                        {
                            case '2':
                                digits2[0]++; //[0] -> 2s
                                break;
                            case '3':
                                digits2[1]++; // [1] -> 3s
                                break;
                            case '4':
                                digits2[0] += 2;
                                break;
                            case '5':
                                digits2[2]++; //[2] -> 5s
                                break;
                            case '6':
                                digits2[0]++;
                                digits2[1]++;
                                break;
                            case '7':
                                digits2[3]++; //[3] ->7s
                                break;
                            case '8':
                                digits2[0] += 3;
                                break;
                            case '9':
                                digits2[1] += 2;
                                break;
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

            int[] values = new int[4] { 2, 3, 5, 7 };
            BigInteger TestResult = 1;
            for (int i = 0; i < 4; i++)
            {
                TestResult = BigInteger.Multiply(TestResult, BigInteger.Pow(values[i], digits1[i]));

            }

            Console.WriteLine(TestResult);
            if (inputCounter < 10)
            { return; }

            BigInteger RESULT10 = 1;
            for (int i = 0; i < 4; i++)
            {
                RESULT10 = BigInteger.Multiply(RESULT10, BigInteger.Pow(values[i], digits2[i]));
            }

            Console.WriteLine(RESULT10);
        }
    }
}
