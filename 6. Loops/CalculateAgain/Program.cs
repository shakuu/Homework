using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAgain
{
    class Program
    {
        static void Main()
        {
            uint numN = uint.Parse(Console.ReadLine());
            uint numK = uint.Parse(Console.ReadLine());
            ulong fact = numN;
            uint div = numN-1;
            unchecked
            {
                
                for (uint i = numN; i > numK+1 ; i--)
                {
                    fact *= div;
                    div--;
                }
            }

            Console.WriteLine(fact);
        }
    }
}
