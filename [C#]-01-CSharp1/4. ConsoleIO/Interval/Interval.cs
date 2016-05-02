using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interval
{
    class Interval
    {
        static void Main(string[] args)
        {
            int numberN = int.Parse(Console.ReadLine());
            int numberM = int.Parse(Console.ReadLine());

            int counter = 0;
            for(int i = Math.Min(numberN, numberM) + 1;
                i< Math.Max(numberN, numberM); i++)
            { if ( i %5 == 0) { counter++; } }

            Console.WriteLine(counter);
        }
    }
}
