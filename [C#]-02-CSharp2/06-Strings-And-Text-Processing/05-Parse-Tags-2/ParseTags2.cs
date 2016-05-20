using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

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


                toParse = toParse.Remove(closeTagIndex, closeTag.Length);
                toParse = toParse.Remove(openTagIndex, openTag.Length);

                openTagIndex = toParse.IndexOf(openTag, ++openTagIndex);
                try
                {
                    closeTagIndex = toParse.IndexOf(closeTag, ++closeTagIndex);
                }
                catch (ArgumentOutOfRangeException)
                {
                    closeTagIndex = -1;
                }

            }

            Console.WriteLine(toParse);
        }
    }
}
