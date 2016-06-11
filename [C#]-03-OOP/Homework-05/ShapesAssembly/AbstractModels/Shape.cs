namespace ShapesAssembly.AbstractModels
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        #region Properties
        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width must be positive");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height must be positive");
                }

                this.height = value;
            }
        }
        #endregion

        public abstract double CalculateSurface();
    }
}
