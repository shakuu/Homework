using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Parse_Tags_2
{
    class ParseTags2
    {
        static void Main()
        {
            var openTag = "<upcase>";
            var closeTag = "</upcase>";

            var toParse = Console.ReadLine();

            var openTagIndex = toParse.IndexOf(openTag);
            var closeTagIndex = toParse.IndexOf(closeTag);

            while (openTagIndex >= 0 && 
                   closeTagIndex >= 0)
            {
                toParse = toParse.Replace(
                    toParse.Substring(
                        openTagIndex,
                        closeTagIndex - openTagIndex),
                     toParse.Substring(
                        openTagIndex,
                        closeTagIndex - openTagIndex).ToUpper());
                

                openTagIndex = toParse.IndexOf(openTag, ++openTagIndex);
                closeTagIndex = toParse.IndexOf(closeTag, ++closeTagIndex);
            }

            toParse = toParse.Replace(openTag.ToUpper(), "");
            toParse = toParse.Replace(closeTag, "");

            Console.WriteLine(toParse);
        }
    }
}
