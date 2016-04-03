using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdDigit
{
    class ThirdDigit
    {
        static void Main(string[] args)
        {
            //INPUT
            int N = int.Parse(Console.ReadLine());
            //OUTPUT
            if ( N.ToString().Length<3)
            { Console.WriteLine("false 0");  }
            else if(N.ToString().ElementAt(N.ToString().Length-3) == '7' ) // SINGLE QUOTES !!!
            { Console.WriteLine("true"); }
            else
            {   Console.WriteLine("false {0}",
                 N.ToString().ElementAt(N.ToString().Length - 3));
            }
        }
    }
}
