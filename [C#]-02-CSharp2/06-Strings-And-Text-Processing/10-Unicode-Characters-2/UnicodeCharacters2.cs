using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace _10_Unicode_Characters_2
{
    class UnicodeCharacters2
    {
        static void Main()
        {
            //var consolestream = Console.In;
            //var input = Console.In.ReadLine();

            var unicodeFormat = @"\u{0}";

            var inputStr = Console.ReadLine();

            var charEnum = StringInfo
                .GetTextElementEnumerator(inputStr);

            var output = new StringBuilder();

            while (charEnum.MoveNext())
            {
                output.Append( 
                    string.Format(
                        unicodeFormat,
                        ((int)charEnum
                            .Current
                            .ToString()[0])
                            .ToString("X4"))
                        );
            }

            Console.WriteLine(output);
        }
    }
}
