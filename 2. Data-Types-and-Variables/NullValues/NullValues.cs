using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullValues
{
    class NullValues
    {
        static void Main(string[] args)
        {
            int? a = null;
            double? d= null;
            Console.WriteLine(a + " " + d); //empty

            a++;
            d++;
            Console.WriteLine(a + " " + d); //empty

            a= 5;
            d = 0;
            Console.WriteLine(a + " " + d); //assigned values
        }
    }
}
