using System;

namespace AllocateArray
{
    class AllocateArray
    {
        static void Main()
        {
            //input N
            int numN = int.Parse(Console.ReadLine());

            //modifier 
            int Mod = 5;

            //N Sized array
            int[] arrayN = new int[numN];

            for (int i = 0; i < arrayN.Length; i++)
            {
                arrayN[i] = i * Mod;
                Console.WriteLine(arrayN[i]);
            }
        }
    }
}
