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

            //first 10
            for (int i = 0; i < 10; i += 2)
            {
                //EVEN
                foreach (char digit in Console.ReadLine().ToUpper())
                {
                    if (digit == 'E') { isRunning = false; i = 10; goto endfor; }
                    else if (digit != '0')
                    {
                        unchecked { resultFirstTen *= (digit - '0'); }
                    }
                }
                //ODD
                if (Console.ReadLine().ToUpper() == "END")
                { isRunning = false; i = 10; }
            endfor:;
            }


            //OTHERS
            while (isRunning)
            {
                //EVEN
                foreach (char digit in Console.ReadLine().ToUpper())
                {
                    if (digit == 'E') { isRunning = false; goto endwhile; }
                    else if (digit != '0')
                    {
                       unchecked { resultOthers *= (digit - '0'); } 
                    }
                }

                //ODD
                if (Console.ReadLine().ToUpper() == "END")
                { isRunning = false; }

            endwhile:;
                counter++;
            }

            if (counter <2)
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
