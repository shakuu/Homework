using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _22_Words_Count
{
    class WordsCount
    {
        static void Main()
        {
            // Same as Letter Count.
            // But store all checked words
            // in a list do avoid multiple checks

            // Get the Input.
            var toParse = Console.ReadLine();

            // Variables.
            var regexFormat = "({0})";

            var Separators = " .,!?:;(){}[]=+"
                .ToCharArray();

            var words = toParse
                .Trim()
                .Split(Separators,
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var checkedWords = new List<string>();

            // Check each word
            foreach (var word in words)
            {
                if (!checkedWords.Contains(word))
                {
                    var curPattern =
                        string.Format(
                            regexFormat,
                            word);

                    var curRegex =
                        new Regex(curPattern);

                    var curMatches = 
                        curRegex.Matches(toParse);

                    // Alternatively store in a dictionary
                    Console.WriteLine(word + " " + curMatches.Count);

                    checkedWords.Add(word);
                }
            }
        }
    }
}
