using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotDivisibleNumbers
{
    class NotDivisibleNumbers
    {
        static void Main()
        {
            int numN = int.Parse(Console.ReadLine());

            Console.Write("1");

            for (int i = 2; i < numN+1; i++)
            {
                if ( i%3 !=0 && i%7 !=0)
                {
                    Console.Write(" {0}", i);
                }
            }
        }
    }
}
