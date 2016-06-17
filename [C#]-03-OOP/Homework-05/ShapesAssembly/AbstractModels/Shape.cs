namespace ShapesAssembly.AbstractModels
{
    using System;

    public abstract class Shape
    {
        private double _width;
        private double _height;

        #region Properties
        public double Width
        {
            get
            {
                return this._width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width must be positive");
                }

                this._width = value;
            }
        }

        public double Height
        {
            get
            {
                return this._height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be positive");
                }

                this._height = value;
            }
        }
        #endregion

        public abstract double CalculateSurface();
    }
}
