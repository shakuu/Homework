using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate3
{
    class Program
    {
        static void Main()
        {
            double numbN = double.Parse(Console.ReadLine());
            double numbK = double.Parse(Console.ReadLine());

            double result = 1;

            for (int i = 1; i < numbN - numbK + 1; i++)
            {

                result *= (i + (numbN - (numbN - numbK))) / i;
            }

            Console.WriteLine(result);
        }
    }
}
