using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine(Enumerable.Range(0, 3).Select(i => int.Parse(Console.ReadLine())).Max());
    }
}