
// TODO: ADD input validation

namespace GSM
{
    using System;

    class Display
    {
        private int size;
        private int colors;

        public Display() { }
        public Display(int size, int colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }
        public int Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                this.colors = value;
            }
        }
    }
}
