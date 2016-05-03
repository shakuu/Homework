using System;

namespace _08_Binary_Short
{
    class Program
    {
        static void Main()
        {
            // input Short 16 bit number
            short toDisplay = short.Parse(Console.ReadLine());

            string toPrint = "";
            string[] BinKey = "0 1".Split(' ');

            for (int i = 0; i < 16; i++)
            {
                // get current 1/ 0
                toPrint = BinKey[(toDisplay & 1)] + toPrint;

                // shift right
                toDisplay >>= 1;
            }

            //print
            Console.WriteLine(toPrint.PadLeft(16, '0'));
        }
    }
}
