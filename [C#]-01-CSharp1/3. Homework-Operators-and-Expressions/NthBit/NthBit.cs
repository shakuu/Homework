using System;

namespace NthBit
{
    class NthBit
    {
        static void Main()
        {
            long number =long.Parse(Console.ReadLine());
            int bitN = int.Parse(Console.ReadLine());
            number = number >> bitN;

            if (number % 2 == 0) { Console.WriteLine("0"); }
            else { Console.WriteLine("1"); }
        }
    }
}
