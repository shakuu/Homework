using System;

using Abstraction.Models;

namespace Abstraction
{
    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine(circle);

            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(rect);
        }
    }
}
