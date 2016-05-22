using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Extract_Sentences_6
{
    class CheckForFloatNumbers
    {
        static void Main()
        {
            // 20/ 100

            // Break on these symbols. 
            var BREAK = new[] { 13, 10, 3, 4, 12, 23, 25 };

            // Input
            var toFindInput = Console.ReadLine();
            var Input = Console.ReadLine();

            // Sentences builder.
            var curSentence = new StringBuilder();

            // Helper Flags
            var isDot = false;

            var toFindWord = FormatInputWord(toFindInput);

            foreach (var letter in Input)
            {
                // Check if End of sentence before 
                // checking for end of line.
                if (isDot && letter != '.')
                {
                    // Start a new sentence
                    isDot = false;

                    // Evaluate the current sentence
                    if (ContainsWord(curSentence.ToString(), toFindWord))
                    {
                        Console.Write(curSentence);
                    }

                    curSentence.Clear();
                }

                // Break on End of Line.
                if (BREAK.Contains(letter))
                {
                    break;
                }

                // Append the current symbol
                curSentence.Append((char)letter);

                if (letter == '.' && !isDot)
                {
                    if (char.IsNumber(curSentence[curSentence.Length - 2]))
                    {
                        // Possibly do something about it
                    }
                    else
                    {
                        isDot = true;
                    }
                    
                }
            }
            
            if (ContainsWord(curSentence.ToString(), toFindWord))
            {
                Console.Write(curSentence);
            }

            Console.WriteLine();
        }

        // Format the Word
        static string FormatInputWord(string inputWord)
        {
            var toReturn = new StringBuilder();

            foreach (var letter in inputWord)
            {
                if (char.IsLetter(letter))
                {
                    toReturn.Append(char.ToLower(letter));
                }
            }

            return toReturn.ToString();
        }

        // Check whether sentence contains current word
        static bool ContainsWord(string sentence, string word)
        {
            // Format the string in a check
            // friendly format, to avoid
            // index out of range checks.
            var checkSentence =
                string.Format(
                    "^{0}$",
                    sentence.ToLower()
                    );

            // Helper variable.
            var wordLength = word.Length;

            // Get first index.
            var wordCurIndex = checkSentence.IndexOf(word);

            while (wordCurIndex >= 0)
            {
                if (!char.IsLetter(checkSentence[wordCurIndex - 1]) &&
                    !char.IsLetter(checkSentence[wordCurIndex + wordLength]))
                {
                    return true;
                }

                // Find the next string match.
                wordCurIndex = checkSentence.IndexOf(word, ++wordCurIndex);
            }

            // If no match has been found 
            // return false.
            return false;
        }
    }
}
