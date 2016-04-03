using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalanNumbers
{
    class CatalanNumbers
    {
        static void Main(string[] args)
        {
            double numN = double.Parse(Console.ReadLine());
            double result = 1;

            for (double i = numN + (double)1; i < (2 * numN) + 1; i++)
            {
                result *= i / ((i - numN) + 1);
            }

            Console.WriteLine(result);
        }
    }
}
