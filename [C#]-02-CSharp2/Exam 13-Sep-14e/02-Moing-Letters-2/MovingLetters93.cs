namespace _02_Moving_Letters
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

    class MovingLetters
    {
        static List<List<char>> words;

        // Step 1
        static StringBuilder RemoveLastLetters()
        {
            var output = new StringBuilder();

            var offset = 0;

            while (words.Count() > 0)
            {
                for (int word = 0; word < words.Count(); word++)
                {
                    if (offset < words[word].Count())
                    {
                        output.Append(words[word][offset]);
                    }
                    else
                    {
                        words.RemoveAt(word);
                        word--;
                    }
                }

                ++offset;
            }

            return output;
        }

        static string MoveLetters(StringBuilder temp)
        {
            var alphabet = "0abcdefghijklmnopqrstuvwxyz";

            var length = temp.Length;

            //var temp = new StringBuilder();

            //temp.Append(input);

            for (int curPosition = 0; curPosition < temp.Length; curPosition++)
            {
                var letterToMove = temp[curPosition];
                var positionsToMove = alphabet.IndexOf(char.ToLower(letterToMove));
                var newPosition = (curPosition + positionsToMove) % length;

                temp.Remove(curPosition, 1);
                temp.Insert(newPosition, letterToMove);
            }

            return temp.ToString();
        }

        static void Main()
        {
            words = Console
                .ReadLine()
                .Split(' ')
                .Select(x => x
                    .Reverse()
                    .ToList())
                .ToList();
            Console.WriteLine(MoveLetters(RemoveLastLetters()));
        }
    }
}