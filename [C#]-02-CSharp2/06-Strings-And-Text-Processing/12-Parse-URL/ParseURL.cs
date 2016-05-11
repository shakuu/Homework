using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _12_Parse_URL
{
    class ParseURL
    {
        static void Main()
        {
            //var test = "ftp://www.telerik-academy.com/Courses/Courses/Details/212";

            var toParse = Console.ReadLine();

            //var URLPattern = new Regex(@"(?<Protocol>\w+)://(?<Server>[\w\.]+)(?<Content>/.*)")

            // Expressions in Brackets are captured in groups.
            // Anything outside of the brackets is matched but 
            // not captured.
            // Optionally can name each group with <Name>
            // 
            var URLPattern = new Regex(@"(.*)://(.*)(/.*)");

            var Match = URLPattern.Match(toParse);

            foreach (var group in Match.Groups)
            {
                if (group.ToString() != toParse)
                {
                    Console.WriteLine(group);
                }
            }
        }
    }
}
