namespace BitArray64Assembly.BitArray64Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BitArray64 : IEnumerable<int>
    {
        private const int Size = 64;

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
            set
            {
                if (value < 0 || 1 < value)
                {
                    throw new ArgumentOutOfRangeException("Bit value can be 1 or 0");
                }

                var mask = (ulong)(1 << index);
                if (value == 1) this.container |= mask;
                else this.container &= ~mask;
            }
        }

        #region Overrides


        #endregion

        #region Interface implementations
        public IEnumerator<int> GetEnumerator()
        {
            for (int index = 0; index < Size; index++)
            {
                var mask = (ulong)(1 << index);
                yield return (int)((this.container & mask) >> index);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
