
namespace PointAndMatrix.Point
{
    using System;

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

        public static double DistanceToOrigin(this Point3D point)
        {
            var distanceXY = (point.X * point.X) + (point.Y * point.Y);
            var distance = Math.Sqrt(distanceXY + (point.Z * point.Z));

            return distance;
        }

        public static double DistanceTo(this Point3D point, Point3D other)
        {
            var deltaX = Math.Abs(point.X - other.X);
            var deltaY = Math.Abs(point.Y - other.Y);
            var deltaZ = Math.Abs(point.Z - other.Z);

            var distanceXY = (deltaX * deltaX) + (deltaY * deltaY);

            var distance = Math.Sqrt(distanceXY + (deltaZ * deltaZ));

            return distance;
        }
    }
}
