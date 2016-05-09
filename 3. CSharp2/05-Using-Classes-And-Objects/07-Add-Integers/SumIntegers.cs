using System;
using System.Linq;

namespace _07_Add_Integers
{
    class SumIntegers
    {
        static void Main()
        {
            Console.WriteLine
                (
                    Console.ReadLine()
                           .Trim(' ')
                           .Split(' ')
                           .Select(int.Parse)
                           .ToList()
                           .Sum()
                );
        }
    }
}
