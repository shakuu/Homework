using System;

namespace _12_Index_Of_Letters
{
    class IndexOfLetters
    {
        static void Main()
        {
            //input
            string theWord = Console.ReadLine();

            //create the array
            char[] Alphabet = new char[26];

            for (int letter = 0; letter < Alphabet.Length; letter++)
            {
                Alphabet[letter] = (char)('a' + letter);
            }

            foreach (char letter in theWord)
            {
                Console.WriteLine(Array.IndexOf(Alphabet, letter));
            }
        }
    }
}
