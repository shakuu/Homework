using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate2
{
    class CalculateTrue
    {
        static void Main()
        {
            int numbN = int.Parse(Console.ReadLine());
            decimal numbX = decimal.Parse(Console.ReadLine());

            decimal[] results = new decimal[numbN + 1];
            results[0] = 1;
            results[1] = 1 / numbX;

            for (int index = 2; index < numbN + 1; index++)
            {
               results[index] = results[index - 1] * (index / numbX);
            }

            Console.WriteLine("{0,0:f5}", results.Sum());
        }
    }
}
