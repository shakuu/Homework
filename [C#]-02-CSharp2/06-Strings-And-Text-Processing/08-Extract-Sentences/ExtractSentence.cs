using System;
using System.Linq;
using System.Text;

namespace _08_Extract_Sentences
{
    class ExtractSentence
    {
        static void Main()
        {
            // Given Sentence Separator : DOT .
            var Separator = '.';

            // Options:
            // .Split into array -> easier
            // .Substring 

            // Alternatively can split each
            // sentence into words. 
            var wordToFind = "in";    //Console.ReadLine();

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
                            Separator));
                }
            }

            Console.WriteLine(output);
        }
    }
}
