using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Replace_Tags_4
{
    class ReplalcleTags4
    {
        static void Main()
        {
            // <a href="url">label</a> [label](url)
            var openTag = "<a href=";
            var closeTag = "</a>";

            // Get input.
            var toParse = Console.ReadLine();

            var openTagPosList = CountOpen(toParse, openTag);
            var closeTagPosList = CountClose(toParse, closeTag);

            for (int curTag = openTagPosList.Count() - 1;
                     curTag >= 0; 
                     curTag--)
            {
                var toAdd = ReplaceTags(toParse.Substring(openTagPosList[curTag], closeTagPosList[curTag] - openTagPosList[curTag]));

                toParse = toParse.Remove(openTagPosList[curTag], closeTagPosList[curTag] - openTagPosList[curTag]);

                toParse = toParse.Insert(openTagPosList[curTag], toAdd);
            }

            Console.WriteLine(toParse);
        }

        // Replace tags
        static string ReplaceTags(string toParse)
        {
            var toRemove = new Dictionary<string, string>
            {
                { "<a href=\"", ""  }, 
                { "\">"       , "~" }, 
                { "</a>"      , ""  }  
            };

            foreach (var tag in toRemove)
            {
                toParse = toParse.Replace(tag.Key, tag.Value);
            }

            var strings = toParse.Split('~').ToArray();

            var format = "[{0}]({1})";
            return string.Format(format, strings[1], strings[0]);
        }

        // Get the indexes
        static List<int> CountOpen(string toParse, string toCount)
        {
            var curPosition = toParse.IndexOf(toCount);

            var toReturn = new List<int>();

            while (curPosition >= 0)
            {
                toReturn.Add(curPosition);

                curPosition = toParse.IndexOf(toCount, ++curPosition);
            }
            
            return toReturn;
        }

        static List<int> CountClose(string toParse, string toCount)
        {
            var curPosition = toParse.IndexOf(toCount);

            var toReturn = new List<int>();

            while (curPosition >= 0)
            {
                curPosition += toCount.Length;
                toReturn.Add(curPosition);

                curPosition = toParse.IndexOf(toCount, ++curPosition);
            }

            return toReturn;
        }
    }
}
