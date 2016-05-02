using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateAgain
{
    class CalculateAgain
    {
        static void Main()
        {
            decimal numN = decimal.Parse(Console.ReadLine());
            decimal numK = decimal.Parse(Console.ReadLine());
            decimal fact = numN;
            decimal div = numN-1;
            unchecked
            {
                
                for (decimal i = numN; i > numK+1 ; i--)
                {
                    fact *= div;
                    div--;
                }
            }

            Console.WriteLine(fact.ToString("F0"));
        }
    }
}
