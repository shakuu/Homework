using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Format_Number
{
    class FormatNumber
    {
        static void Main()
        {
            var toPrint = int.Parse(Console.ReadLine());

            Console.WriteLine("{0, 15:D}", toPrint);
            Console.WriteLine("{0, 15:X}", toPrint);
            Console.WriteLine("{0, 15:P}", toPrint);
            Console.WriteLine("{0, 15:E}", toPrint);
        }
    }
}
