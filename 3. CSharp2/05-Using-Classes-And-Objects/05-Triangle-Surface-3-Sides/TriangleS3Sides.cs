using System;

namespace _05_Triangle_Surface_3_Sides
{
    class TriangleS3Sides
    {
        static void Main()
        {
            double sideA, sideB, sideC;

            double halfP=
            (
                (((sideA = double.Parse(Console.ReadLine())) +
                  (sideB = double.Parse(Console.ReadLine())) +
                  (sideC = double.Parse(Console.ReadLine()))) / 2)
            );

            Console.WriteLine
            (
                Math.Sqrt
                (
                   halfP *
                   (halfP - sideA) *
                   (halfP - sideB) *
                   (halfP - sideC) 
                )
                .ToString("F2")
            );
        }
    }
}
