
namespace PointAndMatrix.Point
{
    using System;
    using Attributes;

    [Version(0, 10)]
    public struct Point3D : IComparable<Point3D>
    {
        #region Fields

        private int x;
        private int y;
        private int z;

        private static readonly Point3D Origin = new Point3D(0, 0, 0);

        #endregion

        #region Constructors

        public Point3D(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #endregion

        #region Properties

        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (value < 0) throw new ArgumentException("All Coordinates must be >= 0");

                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            set
            {
                if (value < 0) throw new ArgumentException("All Coordinates must be >= 0");

                this.y = value;
            }
        }

        public int Z
        {
            get
            {
                return this.z;
            }
            set
            {
                if (value < 0) throw new ArgumentException("All Coordinates must be >= 0");

                this.z = value;
            }
        }

        #endregion

        #region Methods

        public static Point3D operator +(Point3D a, Point3D b)
        {
            var x = a.X + b.X;
            var y = a.Y + b.Y;
            var z = a.Z + b.Z;

            return new Point3D(x, y, z);
        }
        public static Point3D operator -(Point3D a, Point3D b)
        {
            var x = Math.Abs(a.X - b.X);
            var y = Math.Abs(a.Y - b.Y);
            var z = Math.Abs(a.Z - b.Z);

            return new Point3D(x, y, z);
        }
        public override string ToString()
        {
            return string.Format("|{0, 4}|{1, 4}|{2, 4}|", this.X, this.Y, this.Z);
        }
        public int CompareTo(Point3D other)
        {
            // this > other = 1
            // this < other = -1
            // this == other = 0

            var distanceThis = this.DistanceToOrigin();
            var distanceOther = other.DistanceToOrigin();

            if (distanceThis > distanceOther) return 1;
            else if (distanceThis < distanceOther) return -1;
            else if (distanceThis == distanceOther) return 0;

            throw new Exception("Invalid Arguments");
        }

        #endregion
    }
}
