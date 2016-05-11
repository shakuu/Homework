using System;
using System.Collections.Generic;

namespace _15_Replace_Tags
{
    class ReplaceTags
    {
        static void Main()
        {
            // Step 1: Create a dictionary 
            // with items and their replacements
            var Replace = new Dictionary<string, string>()
            {
                { "<a href=\"", "[URL="  }, //
                { "\">"       , "]"      }, //a
                { "</a>"      , "[/URL]" }  //
            };

            var toParse = Console.ReadLine();

            foreach (var tag in Replace)
            {
                toParse = toParse
                    .Replace(
                        tag.Key,
                        tag.Value);
            }

            Console.WriteLine(toParse);
        }
    }
}
