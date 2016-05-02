using System;
using System.Linq;

namespace _2_Compare_Arrays_XOR
{
    class CompareArrays
    {
        static void Main()
        {
            //vars
            int numOfArrays = 2;

            string Win = "Equal";
            string notWin = "Not equal";

            //input Array Size N
            int inputSize = int.Parse(Console.ReadLine());

            int[] arrayOne = new int[inputSize];

            //read values for One
            for (int p = 0; p < numOfArrays; p++)
            {
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    arrayOne[i] = arrayOne[i] ^ int.Parse(Console.ReadLine());
                }
            }
            
            //Output
            if (arrayOne.Sum() == 0)
            {
                Console.WriteLine(Win);
            }
            else
            {
                Console.WriteLine(notWin);
            }
        }
    }
}
