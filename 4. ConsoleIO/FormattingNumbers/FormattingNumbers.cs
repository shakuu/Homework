using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattingNumbers
{
    class FormattingNumbers
    {
        static void Main(string[] args)
        {
            int numA = int.Parse(Console.ReadLine());
            double numB = double.Parse(Console.ReadLine());
            double numC = double.Parse(Console.ReadLine());

            Console.WriteLine("{0,-10:x}|{1, 10:D10}|{2,10:F2}|{3,-10:F3}|",
                numA, Convert.ToUInt64( Convert.ToString(numA, 2)), numB, numC);
        }
    }
}
