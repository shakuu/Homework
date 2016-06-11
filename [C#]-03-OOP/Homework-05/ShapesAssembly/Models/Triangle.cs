namespace ShapesAssembly.Models
{
    using AbstractModels;

    public class Triangle : Shape
    {
        public Triangle(double width, double height)
        {
            base.Width = width;
            base.Height = height;
        }

        public override double CalculateSurface()
        {
            return base.Height * (base.Width / 2);
        }
    }
}
