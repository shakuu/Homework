using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_4_8
{
    class Program
    {
        static void Main()
        {
            long numA = long.Parse(Console.ReadLine());
            long numB = long.Parse(Console.ReadLine());
            long numC = long.Parse(Console.ReadLine());
            long Result = 0;
            switch (numB)
            {
                case 2:
                    Result = numA % numC;
                    break;
                case 4:
                    Result = numA + numC;
                    break;
                case 8:
                    Result = numA * numC;
                    break;
            }

            if (Result % 4 == 0)
            {
                Console.WriteLine(Result / 4);
                Console.WriteLine(Result);
            }
            else 
            {
                Console.WriteLine(Result % 4);
                Console.WriteLine(Result);
            }
        }
    }
}
