using System;

namespace VariablesDataExpressionsConstants.Size
{
    public class Rectangle
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Rectangle GetRotatedSize(Rectangle rectangle, double angleOfRotation)
        {
            var angleOfRotationCosinus = Math.Abs(Math.Cos(angleOfRotation));
            var angleOfRotationSinus = Math.Abs(Math.Sin(angleOfRotation));

            var width = (angleOfRotationSinus * rectangle.width) + (angleOfRotationCosinus * rectangle.height);
            var height = (angleOfRotationCosinus * rectangle.width) + (angleOfRotationSinus * rectangle.height);

            var rotatedRectangle = new Rectangle(width, height);

            return rotatedRectangle;
        }
    }
}
