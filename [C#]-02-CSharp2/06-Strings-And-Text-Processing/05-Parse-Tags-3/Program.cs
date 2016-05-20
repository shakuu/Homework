using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Parse_Tags_3
{
    class Program
    {
        // 100/ 100
        static void Main()
        {
            var openTag = "upcase";
            var closeTag = "/upcase";

            var toParse = Console
                .ReadLine()
                .Split(new char[] { '<', '>' })
                .ToArray();

            var output = new StringBuilder();
            var toUpper = false;

            foreach (var word in toParse)
            {
                if (word == openTag)
                {
                    toUpper = true;
                    continue;
                }

                if (word == closeTag)
                {
                    toUpper = false;
                    continue;
                }

                if (toUpper)
                {
                    output.Append(word.ToUpper());
                }
                else
                {
                    output.Append(word);
                }
            }

            Console.WriteLine(output);
        }
    }
}
