using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateNew
{
    class Program
    {
        static void Main()
        {
            int numN = int.Parse(Console.ReadLine());
            decimal numX = decimal.Parse(Console.ReadLine());

            long factorial = 1;
            decimal powX = 1;
            decimal Sum = 0;

            for ( int i = 1; i < numN +1; i++)
            {
                factorial *= i;
                powX *= numX;
                Sum += factorial / powX;
            }

            Console.WriteLine("{0:F5}", Sum + 1);
        }
    }
}
