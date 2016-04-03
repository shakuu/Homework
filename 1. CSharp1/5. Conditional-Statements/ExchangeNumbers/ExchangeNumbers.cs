using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeNumbers
{
    class ExchangeNumbers
    {
        static void Main()
        {
            double numA = double.Parse(Console.ReadLine());
            double numB = double.Parse(Console.ReadLine());

            if ( numA> numB)
            {
                double temp = numA;
                numA = numB;
                numB = temp;
            }

            Console.WriteLine(numA + " " + numB);
        }
    }
}
