namespace _02_Moving_Letters
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;

    class MovingLetters
    {
        static List<string> words;

        // Step 1
        static StringBuilder RemoveLastLetters()
        {
            var output = new StringBuilder();
            var flags = new int[words.Count()];
            var offset = 1;

            while (words.Count() >flags.Sum())
            {
                for (int word = 0; word < words.Count(); word++)
                {
                    if (words[word].Count() - offset >= 0)
                    {
                        output.Append(words[word][words[word].Count() - offset]);
                    }
                    else
                    {
                        //words.RemoveAt(word);
                        //word--;
                        flags[word] = 1;
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
                .ToList();

            Console.WriteLine(MoveLetters(RemoveLastLetters()));
        }
    }
}
