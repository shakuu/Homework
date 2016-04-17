using System;
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
                if (inputN.Length - currIndex - 1 >= 0)
                {
                    specialSum +=
                        Convert.ToInt32(inputN.Substring(
                            inputN.Length - currIndex - 1, 1))
                        * Convert.ToInt32(inputN.Substring(
                            inputN.Length - currIndex - 1, 1))
                        * (currIndex + 1);
                }
            }

            //secretsequence
            BigInteger sequenceLength = 0;
            BigInteger.DivRem(specialSum, 10, out sequenceLength);

            BigInteger startLetter = 0;
            BigInteger.DivRem(specialSum, 26, out startLetter);
            //startLetter++;

            string secretSequence = "";

            for (int curLetter = 0; curLetter < sequenceLength; curLetter++)
            {
                secretSequence += (char)('A' + startLetter);
                startLetter++;
                if (startLetter > 25)
                {
                    startLetter = 0; // start from A
                }
            }

            //output
            Console.WriteLine(specialSum);
            if (sequenceLength > 0)
            {
                Console.WriteLine(secretSequence);
            }
            else
            {
                Console.WriteLine(inputN + " " +
                    "has no secret alpha-sequence");
            }
        }
    }
}
