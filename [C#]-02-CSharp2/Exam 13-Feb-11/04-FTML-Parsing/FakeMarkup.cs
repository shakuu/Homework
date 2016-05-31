
namespace _04_FTML_Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class FakeMarkup
    {
        // Constants.
        // "upper","lower","toggle","rev","del"
        const string upper = "upper";
        const string lower = "lower";
        const string toggle = "toggle";
        const string rev = "rev";
        const string del = "del";


        private static List<string> words;
        private static List<string> openTags;
        private static List<string> closeTags;
        private static int wordCounter;

        static void Input()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            words = new List<string>();

            for (int line = 0; line < numberOfLines; line++)
            {
                words.AddRange(Console.ReadLine()
                    .Split(new[] { '<', '>' },
                        StringSplitOptions.RemoveEmptyEntries));
            }
        }
        static void BuildTagList()
        {
            openTags = new List<string>()
            {
                "upper",
                "lower",
                "toggle",
                "rev",
                "del"
            };

            closeTags = new List<string>()
            {
                "/upper",
                "/lower",
                "/toggle",
                "/rev",
                "/del"
            };
        }

        static void ParseWords()
        {
            // Check each word 
            // On Open Tag
            // Call ParseTag method
            // Finally Print the 

            for (wordCounter = 0; wordCounter < words.Count; wordCounter++)
            {
                if (openTags.Contains(words[wordCounter]))
                {
                    ParseTag();

                    // Print result
                }
                else
                {
                    Console.WriteLine(words[wordCounter]);
                }
            }

        }
        static string ParseTag()
        {
            // Parse the tag
            // in case of nested tags
            // call recursively 
            var buCounter = wordCounter;

            var tag = words[wordCounter];
            var tagContent = new StringBuilder();

            wordCounter++;
            while (true)
            {
                var nextWord = words[wordCounter];

                if (openTags.Contains(nextWord))
                {
                    // Parse next tag, add the parsed text
                    // to the current tag content.
                    var toAdd = ParseTag();
                    tagContent.Append(toAdd);
                }
                else if (closeTags.Contains(nextWord))
                {
                    
                    // Transform the current string.
                    switch (tag)
                    {
                        case upper:
                            break;
                        case lower:
                            break;
                        case toggle:
                            break;
                        case rev:
                            break;
                        case del:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    tagContent.Append(nextWord);
                }

                wordCounter++;
            }
        }

        static void Main()
        {
            Input();
            ParseWords();
        }
    }
}
