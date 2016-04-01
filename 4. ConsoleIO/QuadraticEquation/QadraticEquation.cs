using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    class QadraticEquation
    {
        static void Main(string[] args)
        {
            //INPUT
            double numA = double.Parse(Console.ReadLine());
            double numB = double.Parse(Console.ReadLine());
            double numC = double.Parse(Console.ReadLine());
            //SOURCE:http://mathworld.wolfram.com/QuadraticEquation.html
            double X1 = ((-numB) - (Math.Sqrt(Math.Pow(numB, 2) - (4 * numA * numC)))) / ( 2*numA);
            double X2 = ((-numB) + (Math.Sqrt(Math.Pow(numB, 2) - (4 * numA * numC)))) / (2 * numA);

            if ( double.IsNaN(X1) && double.IsNaN(X2))
            { Console.WriteLine("no real roots"); }
            else if (!double.IsNaN(X1) && double.IsNaN(X2))
            { Console.WriteLine(X1);  }
            else if (double.IsNaN(X1) && !double.IsNaN(X2))
            { Console.WriteLine(X2); }
            else if (!double.IsNaN(X1) && !double.IsNaN(X2) &&X1==X2)
            { Console.WriteLine(X1); }
            else
            { Console.WriteLine("{0:F2}\n{1:F2}", Math.Min(X1, X2), Math.Max(X1, X2)); }
        }
    }
}
