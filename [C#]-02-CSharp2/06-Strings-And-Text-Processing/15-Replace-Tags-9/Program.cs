
namespace _15_Replace_Tags_9
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var openTag = @"<a ";
            var closeTag = @"</a>";

            var toParse = Console.ReadLine()
                .Split(new[] { openTag, closeTag }, 
                    StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            for (int strIndex = 0; strIndex < toParse.Length; strIndex++)
            {
                if (toParse[strIndex].IndexOf("href=") == 0)
                {
                    var url = GetURL(toParse[strIndex]);
                    var label = GetLabel(toParse[strIndex]);

                    Console.Write( "[{0}]({1})", label, url);
                }
                else
                {
                    Console.Write(toParse[strIndex]);
                }
            }
        }

        static string GetURL(string tag)
        {
            var left = tag.IndexOf("\"");
            var right = tag.IndexOf("\"", left + 1);

            return tag.Substring(left+1, right - left - 1);
        }

        static string GetLabel(string tag)
        {
            var left = tag.IndexOf(">");
            var right = tag.IndexOf("<", left + 1);

            return tag.Substring(left+1);

        }
    }
}
