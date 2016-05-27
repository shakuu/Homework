
namespace _15_Replace_Tags_9
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static string openTag = "<a href=\"";
        static string closeTag = "</a>";
        static string midTag = "\">";

        static void Main()
        {
            var toParse = Console.ReadLine().Split(new[] { openTag, closeTag }, StringSplitOptions.RemoveEmptyEntries);

            var startIndex = toParse[0].Contains(midTag) ?
                             0 : 1;

            for (int strIndex = 0; strIndex < toParse.Length; strIndex++)
            {
                if (toParse[strIndex].Contains(midTag))
                {
                    // Replace
                    var replacement = toParse[strIndex].Split( new[] { midTag }, StringSplitOptions.RemoveEmptyEntries);

                    Console.Write("[{0}]({1})", replacement[1], replacement[0]);
                }
                else
                {
                    Console.Write(toParse[strIndex]);
                }
            }
        }
    }
}
