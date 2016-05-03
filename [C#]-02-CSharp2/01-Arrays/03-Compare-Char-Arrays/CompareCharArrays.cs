using System;

namespace _3_Compare_Char_Arrays
{
    class CompareCharArrays
    {
        static void Main()
        {
            string wordA = Console.ReadLine();
            string wordB = Console.ReadLine();

            if (string.Compare(wordA, wordB)==-1)
            {
                Console.WriteLine("<");
            }
            else if (string.Compare(wordA, wordB) == 1)
            {
                Console.WriteLine(">");
            }
            else
            {
                Console.WriteLine("=");
            }
        }
    }
}
