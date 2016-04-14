using System;

namespace BiggestOf5IF
{
    class BiggestIFs
    {
        static void Main()
        {
            double temp1;
            double temp2;
            double MAX = (temp1 = double.Parse(Console.ReadLine()))
                > (temp2 = double.Parse(Console.ReadLine())) ?
                    temp1 : temp2;
            MAX = (temp1 = double.Parse(Console.ReadLine())) > MAX ?
                    temp1 : MAX;
            MAX = (temp1 = double.Parse(Console.ReadLine())) > MAX ?
                    temp1 : MAX;
            Console.WriteLine((temp1 = double.Parse(Console.ReadLine())) > MAX ?
                    temp1 : MAX);
        }
    }
}
