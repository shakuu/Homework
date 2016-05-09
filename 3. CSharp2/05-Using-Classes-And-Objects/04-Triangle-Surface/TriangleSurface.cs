using System;

namespace _04_Triangle_Surface
{
    class TriangleSurface
    {
        static void Main(string[] args)
        {
            Console.WriteLine   // (h * side) / 2
                (
                    ((double.Parse(Console.ReadLine()) *
                      double.Parse(Console.ReadLine())) / 2)
                      .ToString("F2")
                );
        }
    }
}
