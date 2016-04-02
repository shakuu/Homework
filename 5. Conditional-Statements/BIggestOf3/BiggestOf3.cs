using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIggestOf3
{
    class Program
    {
        static void Main()
        {
            double[] numbs = new double[3];

            for ( int i = 0; i< 3;i++)
            {
                numbs[i] = double.Parse(Console.ReadLine());
            }

            Console.WriteLine(numbs.Max());
        }
    }
}
