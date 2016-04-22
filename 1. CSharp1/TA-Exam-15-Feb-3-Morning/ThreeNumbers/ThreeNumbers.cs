using System;
using System.Linq;

namespace ThreeNumbers
{
    class ThreeNumbers
    {
        static void Main()
        {
            //input
            double[] numbs = new double[3];

            for (int i = 0; i < 3; i++)
            {
                numbs[i] = double.Parse(Console.ReadLine());
            }

            //output
            Console.WriteLine(numbs.Max());
            Console.WriteLine(numbs.Min());
            Console.WriteLine(numbs.Average().ToString("0.00"));
        }
    }
}
