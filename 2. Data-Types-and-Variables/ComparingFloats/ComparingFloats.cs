using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingFloats
{
    class ComparingFloats
    {
        static void Main(string[] args)
        {
            //input
            double eps = 0.000001;
            double a = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());

            if( Math.Abs(a-d)>eps) { Console.WriteLine("False"); }
            else { Console.WriteLine("True"); }
        }
    }
}
