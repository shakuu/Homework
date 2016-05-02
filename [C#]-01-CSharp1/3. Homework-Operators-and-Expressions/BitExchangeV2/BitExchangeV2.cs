using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitExchangeV2
{
    class BitExchangeV2
    {
        public class Bits
        {
            public int Value;
            public int Position;
       
            public Bits(int cvalue, int cPos)
            {
                this.Value = cvalue;
                this.Position = cPos;
            }
        }

        static void Main(string[] args)
        {
            //INPUT 
            uint numN = uint.Parse(Console.ReadLine());
            //Create Bits
            List<Bits> toSwap1 = new List<Bits>();
            List<Bits> toSwap2 = new List<Bits>();
            for (int i = 0; i < 3; i++)
            {
                Bits bit1 = new Bits(0, 3 + i);
                toSwap1.Add(bit1);
            }

            for (int i = 0; i < 3; i++)
            {
                Bits bit1 = new Bits(0,24 + i);
                toSwap2.Add(bit1);
            }
            //Assign Value to all bits
            for (int i=0; i < toSwap1.Count;i++)
            {
                toSwap1[i].Value = 
                    GetValue(numN, toSwap1[i].Position);
                toSwap2[i].Value =
                    GetValue(numN, toSwap2[i].Position);
            }
            //switch Bits
            for (int i =0; i< toSwap1.Count; i++)
            {
                numN = SwapBits(numN, toSwap1[i].Value, toSwap2[i].Position);
                numN = SwapBits(numN, toSwap2[i].Value, toSwap1[i].Position);
            }

            Console.WriteLine((uint)numN);
        }

        static int GetValue(uint Number, int Position)
        {
            long theMask = 1 << Position;
            long result = Number & theMask;

            return (int)(result >> Position);
        }

        static uint SwapBits(uint Number, int newValue, int toPosition )
        {
            long newNumber;
            long mask = 1 << toPosition;
            long bitValue = Number & mask;
            bitValue >>= toPosition;

            if ( bitValue!=newValue)
            {
                newNumber = Number ^ mask;
                return (uint)newNumber;
            }
            else
            {
                return Number;
            }
        }
    }
}
