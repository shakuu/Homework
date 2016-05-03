using System;

namespace _05_Hexadecimal_To_Binary
{
    class HexToBin
    {
        static void Main()
        {
            // input
            string HexNumber = Console.ReadLine();

            // variables 
            string[] HexKey = "0 1 2 3 4 5 6 7 8 9 A B C D E F".Split(' ');

            string BinNumber = "";
            string tempBinNumb = "";

            int toBase = 2;

            for (int curIndex = HexNumber.Length - 1;
                     curIndex >= 0; curIndex--)
            {
                var curDigit = Array.IndexOf(HexKey, HexNumber[curIndex].ToString());

                while (curDigit > 0)
                {
                    tempBinNumb = (curDigit % toBase).ToString() + tempBinNumb;

                    curDigit /= toBase;
                }

                tempBinNumb = tempBinNumb.PadLeft(4, '0');

                BinNumber = tempBinNumb + BinNumber;

                tempBinNumb = "";
            }

            // Print
            Console.WriteLine(BinNumber.TrimStart('0'));
        }
    }
}
