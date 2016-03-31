using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdBitBITWISE
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int mask = 1 << 3;

            int result = number & mask;
            result = result >> 3;
            Console.WriteLine(result);   
        }
    }
}
