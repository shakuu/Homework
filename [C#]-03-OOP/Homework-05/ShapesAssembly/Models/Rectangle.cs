namespace ShapesAssembly.Models
{
    using AbstractModels;

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            base.Width = width;
            base.Height = height;
        }

        public override double CalculateSurface()
        {
            return base.Height * base.Width;
        }
    }
}
