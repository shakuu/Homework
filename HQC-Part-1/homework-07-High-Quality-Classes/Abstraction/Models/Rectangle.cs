using System;
using Abstraction.Contracts;

namespace Abstraction.Models
{
    public class Rectangle : Figure, IRectangle
    {
        public Rectangle(double width, double height)
        {
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
