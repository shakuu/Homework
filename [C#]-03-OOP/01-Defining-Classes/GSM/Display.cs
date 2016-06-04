
namespace GSM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Display
    {
        // Fields
        private int? size;
        private int? colors;

        // Properties.
        public int? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < 0) throw new ArgumentException();
                this.size = value;
            }
        }

        public int? Colors
        {
            get
            {
                return this.colors;
            }
            set
            {
                if (value < 0) throw new ArgumentException();
                this.colors = value;
            }
        }

        // Constructors.
        public Display()
        {
        }

        public Display(int size, int colors)
        {
            this.size = size;
            this.colors = colors;
        }
    }
}
