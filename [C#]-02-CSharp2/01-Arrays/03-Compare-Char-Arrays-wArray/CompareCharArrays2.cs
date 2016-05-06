using System;

namespace _3_Compare_Char_Arrays_wArray
{
    class CompareCharArrays2
    {
        static void Main()
        {
            // 100/ 100 Case Sensitive

            //vars
            string OneSmaller = "<";
            string TwoSmaller = ">";
            string Equal = "=";

            //input
            string inputA = Console.ReadLine();
            string inputB = Console.ReadLine();

            //Step 1: Equal Length
            if (inputA.Length < inputB.Length)
            {
                inputA = inputA.PadRight(inputB.Length, (char)(0));
            }
            else if (inputA.Length > inputB.Length)
            {
                inputB = inputB.PadRight(inputA.Length, (char)(0));
            }

            //Step 2: To Char Arrays
            char[] arrayA = inputA.ToCharArray();
            char[] arrayB = inputB.ToCharArray();

            //Step 3: Compare
            for (int i = 0; i < arrayA.Length; i++)
            {
                if (arrayA[i] < arrayB[i])
                {
                    Console.WriteLine(OneSmaller);
                    return;
                }
                else if (arrayA[i] > arrayB[i])
                {
                    Console.WriteLine(TwoSmaller);
                    return;
                }
            }

            //else they are equal
            Console.WriteLine(Equal);
        }
    }
}
