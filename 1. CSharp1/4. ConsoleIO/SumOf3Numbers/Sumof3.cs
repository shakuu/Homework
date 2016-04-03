using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOf3Numbers
{
    class Sumof3
    {
        static void Main(string[] args)
        {
            float numA = float.Parse(Console.ReadLine());
            float numB = float.Parse(Console.ReadLine());
            float numC = float.Parse(Console.ReadLine());

            Console.WriteLine(numA + numB + numC);
        }
    }
}
