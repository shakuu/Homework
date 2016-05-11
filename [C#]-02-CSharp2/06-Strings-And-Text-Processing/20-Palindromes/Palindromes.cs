using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_Palindromes
{
    class Palindromes
    {
        static void Main()
        {
            // Palindromes aka "ABBA", "civic" 

            // Read input, Split into words array
            // make a dictionary with each unique word reversed
            // check for matches in the text

            // Remove ANY possible symbols
            var Separators = " ,.;:-_!?@~/\\(){}[]+=&^%*".ToCharArray();

            var allWords = Console
                .ReadLine()
                .Trim()
                .Split(Separators, // TODO: Char array with Separators
                StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            // Create a dictionary.
            // Add each unique word in reverse as Key
            var reverseWords =
                new Dictionary<string, string>();

            foreach (var word in allWords)
            {
                var reverse = new StringBuilder();

                for (int letter = word.Length - 1;
                         letter >= 0;
                         letter--)
                {
                    reverse.Append(word[letter]);
                }

                // There will be an exception 
                // TODO: Handle it 
                // Exception will help avoid duplicates
                // System.ArgumentException
                try
                {
                    reverseWords.Add(
                    reverse.ToString(),
                    word
                    );
                }
                catch (System.ArgumentException)
                {
                    continue;
                }
            }

            // Check each key 
            foreach (var word in reverseWords)
            {
                if (allWords.Contains(word.Key))
                {
                    Console.WriteLine(word.Key.ToString());
                }
            }
        }
    }
}
