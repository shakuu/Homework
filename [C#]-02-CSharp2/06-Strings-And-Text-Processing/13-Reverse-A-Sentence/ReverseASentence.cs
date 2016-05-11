using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_Reverse_A_Sentence
{
    class ReverseASentence
    {
        static void Main()
        {
            // Sentence to Reverse.
            var toReverse = Console.ReadLine();

            var Punctuation = new char[]
            {
                '.',
                ',',
                '!',
                '?',
                ' ',
                ':',
                ';',
            };

            // Break the sentence into words to insert
            var Words = toReverse
                .Trim()
                .Split(
                    Punctuation,
                    StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var toInsert = Words.Length - 1;

            var output = new StringBuilder();

            for (int curIndex = 0; curIndex < toReverse.Length; curIndex++)
            {
                if (Punctuation.Contains(toReverse[curIndex]))
                {
                    output.Append(Words[toInsert--]);

                    if (toReverse[curIndex] != ' ')
                    {
                        output.Append(toReverse[curIndex]);
                        output.Append(" ");
                        curIndex++;
                    }
                    else
                    {
                        output.Append(" ");
                    }
                }
            }

            Console.WriteLine(output);
        }
    }
}
