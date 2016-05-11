using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_Forbidden_Words
{
    class ForbiddenWords
    {
        static void Main()
        {
            // TODO: Alternative Solution
            // Build each replacing string when
            // it is needed.

            var replaceWith = "*";

            // Step 1: Build Dictionary
            var ForbiddenWords = new Dictionary<string, string>();

            var inputWords = Console
                .ReadLine()
                .Trim()
                .Split(new char[] { ' ', ',' }, 
                       StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            // TODO: 
            // Add keys for: 
            // as is 
            // upper case
            // lower case
            foreach (var word in inputWords)
            {
                var value = new StringBuilder();

                foreach (var letter in word)
                {
                    value.Append(replaceWith);
                }

                // Possible exception in case of
                // duplicate keys
                try
                {
                    ForbiddenWords.Add(word, value.ToString());
                }
                catch (System.ArgumentException)
                {
                    continue;
                }
                
            }

            // Step 2: Read the input text and 
            // redact it with the dictionary
            var toRedact = Console.ReadLine();

            foreach (var element in ForbiddenWords)
            {
                toRedact = toRedact
                    .Replace(
                        element.Key, 
                        element.Value);
            }

            Console.WriteLine(toRedact);
        }
    }
}
