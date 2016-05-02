using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABnC
{
    class ABnC
    {
        static void Main(string[] args)
        {
            int[] input = new int[3];
            for ( int i =0; i< 3;i++)
            {
                input[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(input.Max());
            Console.WriteLine(input.Min());
            Console.WriteLine(input.Average().ToString("F3"));
        }
    }
}
