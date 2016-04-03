using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToBinary
{
    class DecToBinary
    {
        static void Main()
        {
            long numb =long.Parse(Console.ReadLine());
            string toPrint = "";

            do
            {
                if (numb % 2 == 0)
                {
                    toPrint = "0" + toPrint;
                }
                else
                {
                    toPrint = "1" + toPrint;
                }
                numb = numb >> 1;
            } while (numb > 0);
            Console.WriteLine(toPrint);
        }
    }
}
