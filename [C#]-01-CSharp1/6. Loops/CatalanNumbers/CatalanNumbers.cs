using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace CatalanNumbers
{
    class CatalanNumbers
    {
        static void Main(string[] args)
        {
            long numN = long.Parse(Console.ReadLine());
            BigInteger result = 1;
            BigInteger top = 1;
            BigInteger bottom= 1 ;

            for (long i = numN + 1; i < (2 * numN) + 1; i++)
            {
                top *= i;
                bottom = bottom * ((i - numN) + 1);
               // result *= ( i / ((i - numN) + 1));
            }

            result = top / bottom;
            Console.WriteLine(result.ToString("F0"));
        }
    }
}
