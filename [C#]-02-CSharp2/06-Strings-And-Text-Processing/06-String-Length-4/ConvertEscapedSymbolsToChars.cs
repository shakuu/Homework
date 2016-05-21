using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_String_Length_4
{
    class ConvertEscapedSymbolsToChars
    {
        static Dictionary<string,string> EscSeqDicitonary = 
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
            

            // input 
            var inputStr = Console.ReadLine();

            Console.WriteLine(string.Join("", SplitString(inputStr))); 

            ///////////////////////////////////
            //var test = "0304";

            //Console.WriteLine((char)Convert.ToInt32(test, 16));
        }

        static List<char> SplitString(string inputStr)
        {
            var toReturnList = new List<char>();


            for (int curElement = 0;
                     curElement < inputStr.Length;
                     curElement++)
            {
                // New StringBuilder for each element to add
                var toAddStrBuild = new StringBuilder()
                    .Append(inputStr[curElement]);

                // If current symbol is an escape
                // get whatever is after it
                if (inputStr[curElement] == '\\')
                {
                    // Increment current position, 
                    // read the next element
                    ++curElement;
                    toAddStrBuild.Append(inputStr[curElement]);

                    // In case of Unicode char. \u hhhh
                    // \U hhhh hhhh
                    if (char.ToLower(inputStr[curElement]) == 'u')
                    {
                        toAddStrBuild.Clear();
                        
                        for (int i = 0; i < 4; i++)
                        {
                            ++curElement;
                            toAddStrBuild.Append(inputStr[curElement]);
                        }

                        var ChrToAdd = (char)Convert.ToInt32(toAddStrBuild.ToString(), 16);

                        toReturnList.Add(ChrToAdd);

                        continue;
                    }

                    // \ooo o-> oct number
                    if (char.IsDigit(inputStr[curElement]) &&
                                     inputStr[curElement] < '8')
                    {
                        toAddStrBuild.Clear();

                        for (int i = 0; i < 3; i++)
                        {
                            toAddStrBuild.Append(inputStr[curElement]);
                            ++curElement;
                        }

                        var ChrToAdd = (char)Convert.ToInt32(toAddStrBuild.ToString(), 8);

                        toReturnList.Add(ChrToAdd);

                        continue;
                    }

                    // If it's an escape sequence from the
                    // dictionary.
                    if (EscSeqDicitonary
                        .ContainsKey(toAddStrBuild.ToString()))
                    {
                        var ChrToAdd = (char)Convert.ToInt32(EscSeqDicitonary[toAddStrBuild.ToString()], 16);

                        toReturnList.Add(ChrToAdd);

                        continue;
                    }

                    // Else add \ and whatever is next as separate chars
                    foreach (var chr in toAddStrBuild.ToString())
                    {
                        toReturnList.Add(chr);
                    }

                    continue;
                }

                // If current char is not escaped
                // add it to the list.
                toReturnList.Add(toAddStrBuild[0]);
            }

            while (toReturnList.Count() < 20)
            {
                toReturnList.Add('*');
            }

            return toReturnList;
        }
    }
}
