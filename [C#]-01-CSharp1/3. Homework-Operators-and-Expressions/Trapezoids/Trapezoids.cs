using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trapezoids
{
    class Trapezoids
    {
        static void Main(string[] args)
        {
            //INPUT
            double trapezoidA = double.Parse(Console.ReadLine());
            double trapezoidB = double.Parse(Console.ReadLine());
            double trapezoidH = double.Parse(Console.ReadLine());
            //(A+B)/2*H
            Console.WriteLine(((trapezoidA + trapezoidB) / 2 * trapezoidH).ToString("0.0000000"));
        }
    }
}
