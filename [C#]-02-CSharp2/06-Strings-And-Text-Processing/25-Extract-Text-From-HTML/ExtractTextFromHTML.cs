using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _25_Extract_Text_From_HTML
{
    class ExtractTextFromHTML
    {
        static void Main()
        {
            // Read text, extract 
            // Title
            // Body

            // Step 1: Read Text
            // multiple rows
            var input = new StringBuilder();

            string curLine;

            do
            {
                curLine = Console.ReadLine();

                input.Append(curLine);
                input.AppendLine();

            } while (curLine != "");

            var strInput = input.ToString();

            // Read all text between <Title> Tags 
            // and store it in a list
            var titlePattern = @"<title>(?<Title>.*)</title>";

            var titleRegex = new Regex(titlePattern, RegexOptions.Singleline);

            var titleMatch = titleRegex.Match(strInput);

            var Titles = new List<string>();

            while (titleMatch.Success)
            {
                Titles.Add(titleMatch.Groups[1].Value);

                titleMatch = titleMatch.NextMatch();
            }

            // Step 2: Extract the contents of the Body
            var bodyPattern = @"<body>(?<body>.*)</body>";

            var bodyRegex = new Regex(bodyPattern, RegexOptions.Singleline);

            var bodyMatch = bodyRegex.Match(strInput);

            var Text = bodyMatch.Groups["body"].Value;

            // Step 3: Remove all tags
            for (int curIndex = 0; curIndex < Text.Length; curIndex++)
            {
                if (Text[curIndex] == '<')
                {
                    Text = Text.Remove(
                        curIndex,
                        Text.IndexOf('>') - curIndex + 1);

                    curIndex--;
                }
            }
        }
    }
}
