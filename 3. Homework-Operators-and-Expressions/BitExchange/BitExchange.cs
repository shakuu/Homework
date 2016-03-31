using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExchange
{
    class BitExchange
    {
        static void Main(string[] args)
        {
            //INPUT
            uint number = uint.Parse(Console.ReadLine());
            //OUTPUT -> xx 3 4 5 ... 24 25 26 xxx
            //TO xx 23 24 25 ... 3 4 5 xxx
            string toPrint = Convert.ToString(number, 2);
            for (int i = toPrint.Length;i<32;i++) // format to 32 bit binary
            { toPrint = "0" + toPrint; }

            string tempStr = toPrint.ElementAt(5).ToString() + //extract bits 24, 25, 26
                toPrint.ElementAt(6).ToString() +
                toPrint.ElementAt(7).ToString();

            toPrint=  toPrint.Insert(26, tempStr); // add bits 24.. to pos 3

            tempStr = toPrint.ElementAt(29).ToString() + //extract bits 3, 4, 5
                toPrint.ElementAt(30).ToString() +
                toPrint.ElementAt(31).ToString();

            toPrint= toPrint.Remove(29, 3);
            toPrint = toPrint.Insert(5, tempStr);
            toPrint = toPrint.Remove(8, 3);

            Console.WriteLine(Convert.ToInt64(toPrint, 2));
        }
    }
}
