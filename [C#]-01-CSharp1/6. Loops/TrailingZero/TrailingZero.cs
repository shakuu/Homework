using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.purplemath.com/modules/factzero.htm

namespace TrailingZero
{
    class TrailingZero
    {
        static void Main()
        {
            int numN = int.Parse(Console.ReadLine());
            int power = 1;

            double trailingZeros = 0;

            while (numN > Math.Pow(5, power))
            {
                trailingZeros += (numN - (numN % Math.Pow(5, power))) / Math.Pow(5, power);

                power++;
            }
            Console.WriteLine(trailingZeros);
        }
    }
}
