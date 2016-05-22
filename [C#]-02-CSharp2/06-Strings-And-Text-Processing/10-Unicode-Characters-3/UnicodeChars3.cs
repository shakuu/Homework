using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Unicode_Characters_3
{
    class UnicodeChars3
    {
        static Dictionary<string, string> EscSeqDicitonary =
            new Dictionary<string, string>()
            {
                {@"\a", "0007" },
                {@"\b", "0008" },
                {@"\f", "000C" },
                {@"\n", "000A" },
                {@"\r", "000D" },
                {@"\t", "0009" },
                {@"\v", "000B" }
            };

        static void Main()
        {
            var unicodeFormat = @"\u{0}";

            var input = Console.ReadLine();

            var output = new StringBuilder();

            for (int curIndex = 0; curIndex < input.Length; curIndex++)
            {

                if (input[curIndex] == '\\')
                {
                    if (EscSeqDicitonary.ContainsKey(input.Substring(curIndex, 2)))
                    {
                        output.Append(
                            string.Format(
                                unicodeFormat, 
                                EscSeqDicitonary[input.Substring(curIndex, 2)])
                                );

                        curIndex++;
                    }
                }

                // If a normal char
                output.Append(
                    string.Format(
                        unicodeFormat,
                        ((int)input[curIndex]).ToString("X4"))
                        );
            }

            Console.WriteLine(output);
        }
    }
}
