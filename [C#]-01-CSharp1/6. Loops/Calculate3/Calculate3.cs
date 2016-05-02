using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate3
{
    class Calculate3
    {
        static void Main()
        {
            decimal numbN = decimal.Parse(Console.ReadLine());
            decimal numbK = decimal.Parse(Console.ReadLine());

            decimal result = 1;

            for (int i = 1; i < numbN - numbK + 1; i++)
            {

                result *= (i + (numbN - (numbN - numbK))) / i;
            }

            Console.WriteLine(result.ToString("F0"));
        }
    }
}
