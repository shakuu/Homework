
namespace _15_Replace_Tags_9
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            var openTag = "<a href=\"";
            var closeTag = "</a>";
            var midTag = "\">";

            var toParse = Console.ReadLine().Split(new[] { openTag, closeTag }, StringSplitOptions.RemoveEmptyEntries);
            
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
