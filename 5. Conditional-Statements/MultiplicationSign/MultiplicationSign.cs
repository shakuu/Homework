using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationSign
{
    class MultiplicationSign
    {
        static void Main()
        {
            double numA = double.Parse(Console.ReadLine());
            double numB = double.Parse(Console.ReadLine());
            double numC = double.Parse(Console.ReadLine());

            if ( numA * numB * numC == 0)
            {
                Console.WriteLine("0");
            }
            else if (numA * numB * numC < 0)
            {
                Console.WriteLine("-");
            }
            else if (numA * numB * numC > 0)
            {
                Console.WriteLine("+");
            }
        }
    }
}
