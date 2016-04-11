using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiboncciNumbers
{
    class FibonacciNUmbers
    {
        static void Main(string[] args)
        {
            long numberN = long.Parse(Console.ReadLine());

            long prevNumb1 = 0;
            long prevNumb2 = 1;
            for (int i = 1; i < numberN + 1; i++)
            {
                if (i == 1)
                {
                    Console.Write(i-1);
                    prevNumb1 = i-1; }
                else if (i == 2)
                {
                    Console.Write(", {0}", i-1);
                    prevNumb2 = i-1;}
                else
                {
                    long currFibonacci = prevNumb1 + prevNumb2;
                    Console.Write(", {0}", currFibonacci);
                    prevNumb1 = prevNumb2;
                    prevNumb2 = currFibonacci;}
            }
        }
    }
}
