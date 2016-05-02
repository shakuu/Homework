using System;

namespace _3_Compare_Char_Arrays_wArray
{
    class CompareCharArrays2
    {
        static void Main()
        {
            //vars
            string OneSmaller = "<";
            string TwoSmaller = ">";
            string Equal = "=";           

            //input
            string inputA = Console.ReadLine().ToLower();
            string inputB = Console.ReadLine().ToLower();

            //Step 1: Equal Length
            if (inputA.Length<inputB.Length)
            {
                inputA = inputA.PadRight(inputB.Length, (char)('a' - 1));
            }
            else if (inputA.Length > inputB.Length)
            {
                inputB= inputB.PadRight(inputA.Length, (char)('a' - 1));
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
