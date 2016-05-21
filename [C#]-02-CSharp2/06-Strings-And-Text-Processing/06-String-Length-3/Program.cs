using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _06_String_Length_3
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var Chrs = GetChars( ParseInput(input));

            var output = new StringBuilder();

            foreach (var element in Chrs)
            {
                output.Append(element);
            }

            while (output.Length < 20)
            {
                output.Append("*");
            }

            Console.WriteLine(output);
        }
        
        static List<string> ParseInput(string input)
        {
            var InputChars = new List<string>();
            
            for (int curIndex = 0; curIndex < input.Length; curIndex++)
            {
                var toAdd = new StringBuilder().Append(input[curIndex]);

                if (input[curIndex] == '\\')
                {
                    toAdd.Append(input[curIndex + 1]);
                    curIndex++;
                    // check for uni
                    if (input[curIndex] == 'u')
                    {
                        for (int i = 1; i < 5; i++)
                        {
                            toAdd.Append(input[curIndex + i]);
                        }

                        curIndex += 4;
                    }
                }

                InputChars.Add(toAdd.ToString());
            }

            return InputChars;
        }

        static char[] GetChars(List<string> input)
        {
            var toReturn = new List<char>();

            foreach (var chr in input)
            {
                try
                {
                    toReturn.Add(Convert.ToChar(Regex.Unescape( chr)));
                }
                catch (ArgumentException)
                {
                    foreach (var ltr in chr)
                    {
                        toReturn.Add(ltr);
                    }
                }
            }

            return toReturn.ToArray();
        }
    }
}
