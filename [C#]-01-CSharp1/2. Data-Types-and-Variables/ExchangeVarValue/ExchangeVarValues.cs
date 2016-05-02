using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeVarValue
{
    class ExchangeVarValues
    {
        static void Main(string[] args)
        {
            //input
            int a = 5;
            int b = 10;
            Console.WriteLine("{0} {1}", a, b);

            int c = a;
            a = b;
            b = c;
            Console.WriteLine("{0} {1}", a, b);
        }
    }
}
