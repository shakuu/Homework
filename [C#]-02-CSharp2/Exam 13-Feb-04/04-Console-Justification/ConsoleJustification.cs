
namespace _04_Console_Justification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ConsoleJustification
    {
        // Variables.
        static int width;

        static List<string> words =
           new List<string>();

        // Input: Working.
        static void Input()
        {
            // Line 1: Lines of input text
            var lines = int.Parse(Console.ReadLine());

            // Line 2: Required Width
            width = int.Parse(Console.ReadLine());

            // Lines of text


            for (int line = 0; line < lines; line++)
            {
                words.AddRange
                    (Console.ReadLine()
                        .Trim()
                        .Split(new[] { ' ' },
                            StringSplitOptions
                            .RemoveEmptyEntries));
            }
        }

        // Justify
        // Add words separated by 1 space.
        // When width of current line is longer than width
        // Add spaces between words  right to left till justified
        static void Justify()
        {
            var line = new StringBuilder();
            var curLineLength = 0;
            var startIndex = 0;
            var cur = 0;

            while (true)
            {
                if (curLineLength + words[cur].Length <= width)
                {
                    curLineLength += words[cur].Length;

                    // First Word to use on this line
                    if (curLineLength - words[cur].Length == 0)
                        startIndex = cur;

                    // If line is full then nothing to justify
                    if (curLineLength == width)
                    {
                        // Build a string out of these words
                        // and Print it.
                        BuildASentence(startIndex, cur);
                        curLineLength = 0;
                    }
                    else
                    {
                        // Add an empty space
                        // before the next word
                        curLineLength++;
                    }

                    // Last word available
                    if (cur == words.Count-1)
                    {
                        JustifyASentence(startIndex, cur, curLineLength);
                        return;
                    }

                    cur++;
                }
                else
                {
                    // Build a justified string and print
                    // Words from start index to the one before
                    JustifyASentence(startIndex, cur - 1, curLineLength);
                    curLineLength = 0;
                }
            }
        }
        static void BuildASentence(int first, int last)
        {
            var output = new StringBuilder();

            for (int word = first; word <= last; word++)
            {
                output.Append(words[word]);
                output.Append(" ");
            }

            output.Remove(output.Length - 1, 1);

            Console.WriteLine(output);
        }
        static void JustifyASentence(int first, int last, int length)
        {
            // Case just one word
            if (last == first)
            {
                Console.WriteLine(words[first]);
                return;
            }

            var wordCount = last - first + 1;
            var spacesCount = wordCount - 1;
            var spacesToAdd = width - (length - wordCount);

            var spaces = new StringBuilder[spacesCount]
                .Select(x => x = new StringBuilder())
                .ToArray();

            for (int space = 0; space < spacesToAdd; space++)
            {
                var curSpace = space % spacesCount;

                spaces[curSpace].Append(" ");
            }

            // Build the line
            var output = new StringBuilder();

            for (int word = 0; word < spacesCount; word++)
            {
                output.Append(words[first + word]);
                output.Append(spaces[word]);
            }

            output.Append(words[last]);

            Console.WriteLine(output);
        }

        static void Main()
        {
            Input();
            Justify();
        }
    }
}
