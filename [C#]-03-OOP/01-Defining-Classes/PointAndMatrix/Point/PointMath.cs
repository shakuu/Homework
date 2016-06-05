
namespace PointAndMatrix.Point
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Point3DMath
    {
        public static double Distance(Point3D a, Point3D b)
        {
            var deltaX = Math.Abs(a.X - b.X);
            var deltaY = Math.Abs(a.Y - b.Y);
            var deltaZ = Math.Abs(a.Z - b.Z);

            var distanceXY = (deltaX * deltaX) + (deltaY * deltaY);

            var distance = Math.Sqrt(distanceXY + (deltaZ * deltaZ));

            return distance;
        }
    }
}
