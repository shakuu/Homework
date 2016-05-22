namespace _08_Extract_Sentences_4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    class CustomSplitBytes
    {
        static void Main()
        {
            // Break on these symbols. 
            var BREAK = new[] { 13, 10, 3, 4, 12, 23, 25 };

            // Input
            var toFindInput = Console.ReadLine();
            var consoleInputStream = Console.OpenStandardInput();

            // Helper Variables
            var bufferSize = 64;
            var buffer = new byte[bufferSize];

            // Sentences builder.
            var curSentence = new StringBuilder();

            // Helper Flags
            var isEOL = false;
            var isDot = false;

            var toFindWord = FormatInputWord(toFindInput);

            while (!isEOL)
            {
                var readChars = consoleInputStream.Read(buffer, 0, bufferSize);

                for (int curChar = 0; curChar < readChars; curChar++)
                {
                    // Check if End of sentence before 
                    // checking for end of line.
                    if (isDot && buffer[curChar] != '.')
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
                    if (BREAK.Contains(buffer[curChar]))
                    {
                        isEOL = true;
                        break;
                    }

                    // Append the current symbol
                    curSentence.Append((char)buffer[curChar]);

                    if (buffer[curChar] == '.' && !isDot)
                    {
                        isDot = true;
                    }
                }
            }

            consoleInputStream.Close();
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
