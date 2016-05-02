using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclePA
{
    class CirclePA
    {
        static void Main(string[] args)
        {
            double circleR = double.Parse(Console.ReadLine());
            Console.WriteLine("{0} {1}",
                (2 * Math.PI * circleR).ToString("0.00"),
                (Math.PI * Math.Pow(circleR,2)).ToString("0.00"));
        }
    }
}
