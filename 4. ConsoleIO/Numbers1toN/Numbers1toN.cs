using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers1toN
{
    class Numbers1toN
    {
        static void Main(string[] args)
        {
            int maxNumber = int.Parse(Console.ReadLine());

            for ( int i = 1; i< maxNumber+1; i++)
            { Console.WriteLine(i); }
        }
    }
}
