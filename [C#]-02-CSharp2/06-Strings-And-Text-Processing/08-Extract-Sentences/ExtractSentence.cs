using System;
using System.Linq;
using System.Text;

namespace _08_Extract_Sentences
{
    class ExtractSentence
    {
        static void Main()
        {
            // TODO: 30/ 100

            // Given Sentence Separator : DOT .
            var Separator = ".".ToCharArray();

            // Options:
            // .Split into array -> easier
            // .Substring 

            // Alternatively can split each
            // sentence into words. 
            var wordToFind = Console.ReadLine();

            // Each separate word is surrounded
            // by empty spaces.
            var formatToFind = " {0} ";

            var toFind = 
                string.Format(
                    formatToFind, 
                    wordToFind);

            var Sentences = Console
                .ReadLine()
                .Trim()
                .Split(Separator)
                .ToArray();

            var output = new StringBuilder();

            var sentenceFormat = "{0}{1}";

            foreach (var sentence in Sentences)
            {
                if (sentence.Contains(toFind))
                {
                    output.Append(
                        string.Format(
                            sentenceFormat,
                            sentence,
                            Separator[0]));
                }
            }

            Console.WriteLine(output);
        }
    }
}
