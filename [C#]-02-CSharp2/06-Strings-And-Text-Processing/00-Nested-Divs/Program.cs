using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _00_Nested_Divs
{
    class Program
    {
        static void Main()
        {
            var openTag = "<div class=\"nested-div\">";
            var closeTag = "</div>";

            var divs = 60;

            var htmlBuilder = new StringBuilder();

            var file = @"D:\GitHub\Homework\[CSS]-01-Basics\02-CSS-Presentation\03-Nested-Divs\generate.txt";

            using (var writer = new StreamWriter(file) )
            {
                for (int curLine = 0; curLine < divs; curLine++)
                {
                    writer.WriteLine(openTag);
                }

                for (int curLine = 0; curLine < divs; curLine++)
                {
                    writer.WriteLine(closeTag);
                }
            }
        }
    }
}
