using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdBit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            number = number >> 2;

            if (number % 2 == 0) { Console.WriteLine("0"); }
            else { Console.WriteLine("1"); }   
        }
    }
}
