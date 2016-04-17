using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SecretNumbers
{
    class SecretNumbers
    {
        static void Main()
        {
            //input StringN
            string inputN = Console.ReadLine();

            //special sum right to left - last element odd, next to last even
            BigInteger specialSum = 0;
            for (int currIndex = 1; currIndex <= inputN.Length; currIndex += 2)
            {
                //Odd
                specialSum +=
                    Convert.ToInt32(inputN.Substring(inputN.Length - currIndex, 1))
                    * currIndex * currIndex;
                //Even
                if (currIndex - 1 >= 0)
                {
                    specialSum +=
                        Convert.ToInt32(inputN.Substring(
                            inputN.Length - currIndex - 1 , 1))
                        * Convert.ToInt32(inputN.Substring(
                            inputN.Length - currIndex - 1 , 1))
                        * (currIndex +1) ;
                }
            }
        }
    }
}
