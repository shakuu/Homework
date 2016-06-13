namespace BitArray64Assembly.BitArray64Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BitArray64
    {
        private ulong container;

        public BitArray64()
        {
            this.container = 0;
        }

        public int this[int index]
        {
            get
            {
                if (!(0 <= index && index <= 63))
                {
                    throw new IndexOutOfRangeException("Index must be: 0 <= index <= 63");
                }

                var mask = (ulong)(1 << index);
                var result = (int)((this.container & mask) >> index);

                return result;
            }
        }
    }
}
