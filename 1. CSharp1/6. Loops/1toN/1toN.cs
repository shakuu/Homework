using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1toN
{
    class Program
    {
        static void Main()
        {
            int numN = int.Parse(Console.ReadLine());

            Console.Write("1");

            for( int i = 2; i < numN+1;i++)
            {
                Console.Write(" {0}", i);
            }
        }
    }
}
