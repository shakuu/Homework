using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthBitBITWISE
{
    class NthBitBITWISE
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());

            int mask = 1 << position;

            int result = number & mask;
            result = result >> position;
            Console.WriteLine(result);
        }
    }
}
