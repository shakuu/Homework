using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Compare_Arrays
{
    class CompareArrays
    {
        static void Main(string[] args)
        {
            //vars
            bool isEqual = true;

            string Win = "Equal";
            string notWin = "Not equal";

            //input Array Size N
            int inputSize = int.Parse(Console.ReadLine());

            int[] arrayOne = new int[inputSize];
            int[] arrayTwo = new int[inputSize];

            //read values for One
            for (int i = 0; i < arrayOne.Length; i++)
            {
                arrayOne[i] = int.Parse(Console.ReadLine());
            }

            //read values for Two
            for (int i = 0; i < arrayOne.Length; i++)
            {
                arrayTwo[i] = int.Parse(Console.ReadLine());
            }

            //Compare
            for (int i = 0; i < arrayOne.Length; i++)
            {
                if (arrayOne[i] != arrayTwo[i])
                {
                    isEqual = false;
                }
            }

            //Output
            if (isEqual)
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
