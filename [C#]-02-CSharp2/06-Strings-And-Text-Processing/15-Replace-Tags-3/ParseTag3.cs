using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Replace_Tags_3
{
    class ParseTag3
    {
        static void Main()
        {
            // <a href="url">label</a> [label](url)
            //var openTag = "<a href";
            var closeTag = "</a>";
            
            // Get input.
            var toParse = Console.ReadLine();
            var posOpenTag = new List<int>();
            var posCloseTag = new List<int>();

            // get strings to parse positions
            for (int curIndex = 0; curIndex < toParse.Length; curIndex++)
            {
                if (toParse[curIndex] == '<')
                {
                    if (isOpenAnchor(toParse, curIndex))
                    {
                        posOpenTag.Add(curIndex);
                    }

                    if (isCloseAnchor(toParse, curIndex))
                    {
                        posCloseTag.Add(curIndex+closeTag.Length);
                    }
                }
            }

            for (int i = posOpenTag.Count() - 1; i >= 0; i--)
            {
                var toAdd = ConvertTag(toParse.Substring(posOpenTag[i], posCloseTag[i] - posOpenTag[i]));

                toParse = toParse.Remove(posOpenTag[i], posCloseTag[i] - posOpenTag[i]);

                toParse = toParse.Insert(posOpenTag[i], toAdd);
                
            }

            Console.WriteLine(toParse);
        }

        // TODO: EXCEPTION = return false
        static bool isOpenAnchor(string toParse, int position)
        {
            var openTag = "<a href";

            var isOpenTag = true;

            for (int i = 0; i < openTag.Length; i++)
            {
                if (toParse[position+i] != openTag[i])
                {
                    isOpenTag = false;
                    break;
                }
            }

            return isOpenTag;
        }

        static bool isCloseAnchor(string toParse, int position)
        {
            var openTag = "</a>";

            var isCloseTag = true;

            for (int i = 0; i < openTag.Length; i++)
            {
                if (toParse[position + i] != openTag[i])
                {
                    isCloseTag = false;
                    break;
                }
            }

            return isCloseTag;
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
