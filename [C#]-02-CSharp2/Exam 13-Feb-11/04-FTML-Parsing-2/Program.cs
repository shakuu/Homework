namespace _04_FTML_Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // 60 / 100
    // RunTimeErrors
    // Possible split lines

    class FakeMarkup
    {
        // Constants.
        // "upper","lower","toggle","rev","del"
        const string upper = "upper";
        const string lower = "lower";
        const string toggle = "toggle";
        const string rev = "rev";
        const string del = "del";


        private static List<List<string>> words;
        private static List<string> openTags;
        private static List<string> closeTags;
        private static int curWordIndex;
        private static int curWordLine;

        // Input: Working.
        static void Input()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            words = new List<List<string>>();

            for (int line = 0; line < numberOfLines; line++)
            {
                words.Add(Console.ReadLine()
                    .Split(new[] { '<', '>' },
                        StringSplitOptions.RemoveEmptyEntries)
                    .ToList());
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

            for (curWordLine = 0;
                 curWordLine < words.Count;
                 curWordLine++)
            {
                for (curWordIndex = 0;
                     curWordIndex < words[curWordLine].Count;
                     curWordIndex++)
                {
                    if (openTags
                        .Contains(words[curWordLine][curWordIndex]))
                    {
                        var result = ParseTag();

                        // Print result
                        Console.Write(result);
                    }
                    else
                    {
                        Console
                            .Write(words[curWordLine][curWordIndex]);
                    }
                }
                // Inser a new line for each row
                Console.WriteLine();
            }
        }
        static string ParseTag()
        {
            // Parse the tag
            // in case of nested tags
            // call recursively 
            var openTagIndex = curWordIndex;

            var tag = words[curWordLine][curWordIndex];
            var tagContent = new StringBuilder();

            curWordIndex++;
            while (true)
            {
                // Current Word on Exit index 

                var curWord = words[curWordLine][curWordIndex];

                if (openTags.Contains(curWord))
                {
                    // Parse next tag, add the parsed text
                    // to the current tag content.
                    var toAdd = ParseTag();
                    tagContent.Append(toAdd);
                }
                else if (closeTags.Contains(curWord))
                {
                    var toAdd = "";

                    // Transform the current string.
                    switch (tag)
                    {
                        case upper:
                            toAdd = TagUpper(tagContent);
                            break;
                        case lower:
                            toAdd = TagLower(tagContent);
                            break;
                        case toggle:
                            toAdd = TagToggle(tagContent);
                            break;
                        case rev:
                            toAdd = TagReverse(tagContent);
                            break;
                        case del:
                            toAdd = TagDelete(tagContent);
                            break;
                        default:
                            break;
                    }

                    // Remove the current tags
                    words[curWordLine].RemoveAt(curWordIndex);
                    words[curWordLine].RemoveAt(openTagIndex);

                    // Word index is index of closing tag - 1 
                    curWordIndex -= 2;
                    return toAdd;
                }
                else
                {
                    tagContent.Append(curWord);
                }

                curWordIndex++;
            }
        }

        private static string TagDelete(StringBuilder tagContent)
        {
            return "";
        }
        private static string TagReverse(StringBuilder tagContent)
        {
            var output = new StringBuilder();

            for (int chr = tagContent.Length - 1; chr >= 0; chr--)
            {
                output.Append(tagContent[chr]);
            }

            return output.ToString();
        }
        private static string TagToggle(StringBuilder tagContent)
        {
            var output = new StringBuilder();

            for (int chr = 0; chr < tagContent.Length; chr++)
            {
                if (char.IsLower(tagContent[chr]))
                    output.Append(char.ToUpper(tagContent[chr]));
                else output.Append(char.ToLower(tagContent[chr]));
            }

            return output.ToString();
        }
        private static string TagLower(StringBuilder tagContent)
        {
            return tagContent.ToString().ToLower();
        }
        private static string TagUpper(StringBuilder tagContent)
        {
            return tagContent.ToString().ToUpper();
        }

        static void Main()
        {
            Input();
            BuildTagList();
            ParseWords();
        }
    }
}
