using System;
using System.Numerics;

namespace ConsoleApp3
{
    class ConsoleApp3
    {
        static void Main()
        {

            //Console.BufferHeight = Int16.MaxValue - 1;
            //Console.BufferWidth = Int16.MaxValue - 1;

            BigInteger resultFirstTen = 1;
            BigInteger resultOthers = 1;
            
            int counter = 0; //first 10 elements or less
            bool isRunning = true;

            while (isRunning)
            {
                if (counter % 2 == 0)
                {
                    foreach (char digit in Console.ReadLine().ToUpper())
                    {
                        if (digit == 'E') { isRunning=false; break; }
                        else if (digit != '0')
                        {
                            if (counter < 10) { unchecked { resultFirstTen *= (digit - '0'); } }
                            else { unchecked { resultOthers *= (digit - '0'); } }
                        }
                    }
                }
                else
                {
                    if (Console.ReadLine().ToUpper() == "END")
                    { isRunning=false; }

                }
                counter++;
            }

            if (counter<13)
            {
                Console.WriteLine(resultFirstTen.ToString("R"));
            }
            else
            {
                Console.WriteLine(resultFirstTen.ToString("R"));
                Console.WriteLine(resultOthers.ToString("R"));
            }
        }
    }
}
