using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _25_Extract_Text_From_HTML
{
    class ExtractTextFromHTML
    {
        static void Main()
        {
            // Read text, extract 
            // Title
            // Body

            // Step 1: Read Text
            // multiple rows
            var input = new StringBuilder();

            string curLine;

            do
            {
                curLine = Console.ReadLine();

                input.Append(curLine);
                input.AppendLine();

            } while (curLine != "");

            var strInput = input.ToString();

            // Read Title , if any.

            // Then Read everything else
            var titlePattern = @".title.([\w\d.]+)./title.";

            var titleRegex = new Regex(titlePattern);

            var titleMatch = titleRegex.Matches(strInput);

            foreach (var match in titleMatch)
            {
                Console.WriteLine(match);
            }
        }
    }
}
