
namespace PointAndMatrix.Point
{
    using System;

    public struct Point3D
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

        public override string ToString()
        {
            return string.Format("|{0, 4}|{1, 4}|{2, 4}|", this.X, this.Y, this.Z);
        }

        #endregion
    }
}
