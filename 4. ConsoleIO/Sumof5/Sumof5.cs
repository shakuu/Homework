using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sumof5
{
    class Sumof5
    {
        static void Main(string[] args)
        {
            int[] numbs = new int[5];

            for (int i =0;i<5;i++)
            { numbs[i] = int.Parse(Console.ReadLine()); }

            Console.WriteLine(numbs.Sum());
        }
    }
}
