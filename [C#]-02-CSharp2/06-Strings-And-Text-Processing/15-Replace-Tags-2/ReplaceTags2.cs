using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _15_Replace_Tags_2
{
    class ReplaceTags2
    {
        // WORKING, SLOW, MEMORY

        static void Main()
        {
            // <a href="url">label</a> [label](url)
            var openTag = "<a href";
            var closeTag = "</a>";


            // Get input.
            var toParse = Console.ReadLine();

            var curOpenTagIndex = toParse.IndexOf(openTag);

            var patternOpenTag = "<a href+";
            var patternCloseTag = "</a>";

            var matchOpenTag = Regex.Match(toParse, patternOpenTag);
            var matchCloseTag = Regex.Match(toParse, patternCloseTag);

            while (matchOpenTag.Success)
            {
               

                var expressionLength = (matchCloseTag.Index + closeTag.Length) - matchOpenTag.Index;

                var newTag = ConvertTag(toParse.Substring(matchOpenTag.Index, expressionLength));

                toParse = toParse.Remove(matchOpenTag.Index, expressionLength);

                toParse = toParse.Insert(matchOpenTag.Index, newTag);

                matchOpenTag = Regex.Match(toParse, patternOpenTag);
                matchCloseTag = Regex.Match(toParse, patternCloseTag);
            }

            Console.WriteLine(toParse);
        }
        
        static string ConvertTag(string curExpression)
        {
            // label url
            var returnFormat = "[{0}]({1})";

            var buildURL = new StringBuilder();
            var buildLabel = new StringBuilder();
            var isURL = false;
            var isLabel = false;

            for (int index = 0; index < curExpression.Length; index++)
            {
                if (curExpression[index] == '"')
                {
                    isURL = !isURL;
                    continue;
                }

                if (curExpression[index] == '>' && isLabel == false)
                {
                    isLabel = true;
                    continue;
                }

                if (curExpression[index] == '<' && isLabel == true)
                {
                    isLabel = false;
                    continue;
                }

                if (isLabel)
                {
                    buildLabel.Append(curExpression[index]);
                }

                if (isURL)
                {
                    buildURL.Append(curExpression[index]);
                }
            }
        

            return string.Format(returnFormat, buildLabel.ToString(), buildURL.ToString());
        }
    }
}
