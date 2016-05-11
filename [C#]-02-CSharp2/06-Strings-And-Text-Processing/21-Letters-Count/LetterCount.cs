using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _21_Letters_Count
{
    class LetterCount
    {
        static void Main()
        {
            // Search With Regex
            // Create a Format Regex 
            // Insert a variable in it
            // TODO: Create an Alphabet
            // avoid duplicate checks

            // Variables: 
            var regexFormat = "({0})";

            var alphabet = new char[26];

            for (int letter = 0;
                     letter < alphabet.Length;
                     letter++)
            {
                alphabet[letter] = (char)('a' + letter);
            }

            // Input
            var toParse = Console.ReadLine();
            // Check for each letter
            foreach (var letter in alphabet)
            {
                if (toParse.Contains(letter))
                {
                    // Get Pattern out of the 
                    // pre defined format
                    var curPattern =
                        string.Format(
                            regexFormat,
                            letter);

                    // Regex out of the pattern.
                    var curRegex =
                        new Regex(curPattern);

                    // Find Matches.
                    var curMatches =
                        curRegex.Matches(toParse);

                    // Print, alternatively store
                    // in a dictionary
                    Console.WriteLine(
                        letter + 
                        " " + 
                        curMatches.Count);
                }
            }
        }
    }
}
