using System;
using System.Collections;
//using System.Linq;

namespace _15_Prime_Number_Faster
{
    class SieveOfErathosthene
    {
        static void Main()
        {
            //https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
            //https://en.wikipedia.org/wiki/Wheel_factorization

            // input Range N 
            int Range = int.Parse(Console.ReadLine());

            // List of Odd Numbers
            BitArray Flags = new BitArray(Range + 1);


            // Account for the assumptions 
            if (Range == 2)
            {
                Console.WriteLine("2");
                return;
            }

            if (Range == 3 || Range == 4)
            {
                Console.WriteLine("3");
                return;
            }

            if (Range == 5)
            {
                Console.WriteLine("5");
                return;
            }

            // Variables
            int currStep = 7;

            if (currStep * currStep <= Range)
            {
                while (true)
                {
                    // stop if square of current step is larger than range
                    if (Flags.Get(currStep * currStep) == true)
                    {
                        break;
                    }

                    // Each element
                    for (int i = currStep * currStep; i < Flags.Length; i += currStep)
                    {
                        Flags.Set(i, true);
                    }

                    // find the next unflagged number
                    for (int i = currStep + 1; i * i < Flags.Length; i++)
                    {
                        if (Flags.Get(i) == false && (i & 1) != 0 && i % 3 != 0 && i % 5 != 0)
                        {
                            currStep = i;
                            break;
                        }
                    }
                }
            }

            // Find the First Unflagged Number
            int toPrint = -1;

            for (int i = Flags.Length - 1; i >= 0; i--)
            {
                if (Flags.Get(i) == false)
                {
                    if ((i & 1) != 0 && i % 3 != 0 && i % 5 != 0)
                    {
                        toPrint = i;
                        break;
                    }
                }
            }

            Console.WriteLine(toPrint);
        }
    }
}
