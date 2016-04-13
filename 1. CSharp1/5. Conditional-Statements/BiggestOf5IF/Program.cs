using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggestOf5IF
{
    class Program
    {
        static void Main()
        {
            double temp;
            double MAX = double.MinValue;
            for (int i = 0; i < 5; i++)
            {
                MAX =( temp = double.Parse(Console.ReadLine())) > MAX ?
                    temp : MAX;
            }
        }
    }
}
