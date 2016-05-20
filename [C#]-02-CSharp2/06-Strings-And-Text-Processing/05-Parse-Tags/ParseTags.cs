using System;

namespace _05_Parse_Tags
{
    class ParseTags
    {
        static void Main()
        {
            // TODO: 30/ 100

            // Given : tags
            var openTag = "<upcase>";
            var closeTag = "</upcase>";

            var toParse = Console.ReadLine();

            for (int curIndex = 0;
                     curIndex < toParse.Length;
                     curIndex++)
            {
                if (toParse.IndexOf(openTag, curIndex) < 0 ||
                    toParse.IndexOf(closeTag, curIndex) < 0)
                {
                    break;
                }

                var startPos = toParse
                    .IndexOf(openTag, curIndex) +
                    openTag.Length;

                var endPos = toParse
                    .IndexOf(closeTag, startPos);

                var length = endPos - startPos;

                toParse = toParse.Replace(
                    toParse.Substring(startPos, length),
                    toParse.Substring(startPos, length).ToUpper());

                curIndex = startPos + 1;
            }

            toParse = toParse.Replace(openTag, "");
            toParse = toParse.Replace(closeTag, "");

            Console.WriteLine(toParse);
        }
    }
}
