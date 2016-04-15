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
            double numX = double.Parse(Console.ReadLine());

            int factorial = 1;
            double Sum = 0;

            for ( int i = 1; i < numN +1; i++)
            {
                factorial *= i;
                Sum += factorial / Math.Pow(numX, i);
            }

            Console.WriteLine("{0:F5}", Sum + 1);
        }
    }
}
