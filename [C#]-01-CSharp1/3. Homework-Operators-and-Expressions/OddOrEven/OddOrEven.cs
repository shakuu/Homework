using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOrEven
{
    class OddOrEven
    {
        static void Main(string[] args)
        {
            sbyte number = sbyte.Parse( Console.ReadLine());
            if(number%2==0) { Console.WriteLine("even {0}", number); }
            else { Console.WriteLine("odd {0}", number); } 
        }
    }
}
