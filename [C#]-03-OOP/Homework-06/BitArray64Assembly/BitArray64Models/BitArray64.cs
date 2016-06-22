namespace BitArray64Assembly.BitArray64Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    public class BitArray64 : IEnumerable<int>
    {
        private const int Size = 64;

        private ulong container;
        
        public BitArray64()
        {
            this.container = 0;
        }

        public BitArray64(string binary)
        {
            this.Container = Convert.ToUInt64(binary, 2);
        }

        public BitArray64(ulong value)
        {
            this.Container = value;
        }
       

        private ulong Container
        {
            get
            {
                return this.container;
            }
            set
            {
                if (value < ulong.MinValue || ulong.MaxValue < value)
                {
                    throw new ArgumentOutOfRangeException("Invalid value");
                }

                this.container = value;
            }
        }

        public ulong ULongValue
        {
            get
            {
                return this.Container;
            }
        }

        public int this[int index]
        {
            get
            {
                if (!(0 <= index && index <= 63))
                {
                    throw new Exception("Index must be: 0 <= index <= 63");
                }

                var mask = ((ulong)1 << index);
                var result = (int)((this.container & mask) >> index);

                return result;
            }
            set
            {
                if (value < 0 || 1 < value)
                {
                    throw new Exception("Bit value can be 1 or 0");
                }

                var mask = ((ulong)1 << index);
                if (value == 1) this.container |= mask;
                else this.container &= ~mask;
            }
        }
        
        public static bool operator ==(BitArray64 one, BitArray64 other)
        {
            return one.Equals(other);
        }

        public static bool operator !=(BitArray64 one, BitArray64 other)
        {
            return !one.Equals(other);
        }
       
        public override string ToString()
        {
            var output = new StringBuilder();

            for (int index = Size - 1; index >= 0; index--)
            {
                output.Append(this[index]);

                if ((index + 1) % 8 == 0 && index != 63)
                {
                    output.Append(' ');
                }
            }

            return output.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(BitArray64))
            {
                throw new ArgumentException("Argument is not BitArray64");
            }

            var other = obj as BitArray64;

            if ((this.container ^ other.container) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int result = 37;
            int multiply = 373;

            unchecked
            {
                foreach (var value in this)
                {
                    result = multiply * result + value;
                }
            }

            return result;
        }
        
        
        public IEnumerator<int> GetEnumerator()
        {
            for (int index = 0; index < Size; index++)
            {
                var mask = ((ulong)1 << index);
                var result = (int)((this.container & mask) >> index);
                
                yield return (int)result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
    }
}
