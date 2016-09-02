using System;

namespace CohesionAndCoupling
{
    public static class Utils3D
    {
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;
            return volume;
        }

        public static double CalcDiagonal3D(double width, double height, double depth)
        {
            double distance = CalcDistance3D(0, 0, 0, width, height, depth);
            return distance;
        }
    }
}
