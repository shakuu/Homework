using System;

namespace _06_Triangle_Surface_2_Sides_Angle
{
    class TriangleS2SidesAngle
    {
        static void Main()
        {
            Console.WriteLine
                (
                    (double.Parse(Console.ReadLine()) *
                     double.Parse(Console.ReadLine()) *
                     (Math.Sin
                        (
                            double.Parse(Console.ReadLine()) *
                            Math.PI / 180
                        )
                        / 2)
                    )
                    .ToString("F2")
                );
        }
    }
}
