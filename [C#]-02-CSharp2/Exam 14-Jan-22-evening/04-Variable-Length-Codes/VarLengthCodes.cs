
namespace _04_Variable_Length_Codes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;

    class VarLengthCodes
    {
        // Input variables.
        static string[] input;
        static StringBuilder output;
        static Dictionary<string, string> codes;


        // Input Line 1: Encoded text
        static void ReadTextToDecode()
        {
            // Read the line, split,
            // convert each number into 
            // its binary representation
            input = Console.ReadLine()
                .Trim()
                .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Select(x => Convert.ToString(x, 2))
                .ToArray();
        }

        // Building Keys/ Values Incorrectly
        // Input Line 2: Number of lines
        // Input Line 3 to N : Codes
        static void BuildDictionary()

        {
            codes = new Dictionary<string, string>();

            var linesOfCodes = int.Parse(Console.ReadLine());

            for (int line = 0; line < linesOfCodes; line++)
            {
                var inputLine = Console.ReadLine();

                // "m3"
                // Key = 111, Value = m
                var value = inputLine[0];

                var keyLength = int.Parse(inputLine.Substring(1).Trim());
                
                var key = new StringBuilder();

                for (int length = 0; length < keyLength; length++) key.Append(1);

                codes.Add(key.ToString(), value.ToString());
            }
        }
        
        static void DecodeInput()
        {
            output = new StringBuilder();

            var curCode = new StringBuilder();

            foreach (var textByte in input)
            {
                foreach (var textBit in textByte)
                {
                    // If 1 add to current code
                    if (textBit == '1') curCode.Append(textBit);

                    // If 0 decode the current char and 
                    // reset code.
                    else if (textBit == '0')
                    {
                        // TODO: Possible Errors on empty curCode
                        // ( consequitive zeros )
                        if (curCode.Length > 0)
                        {
                            // Check if Key exists ( exceptions )
                            if (codes.ContainsKey(curCode.ToString()))
                            {
                                output.Append(codes[curCode.ToString()]);
                            }
                        }

                        curCode.Clear();
                    }
                }
            }
        }

        static void Main()
        {
            // 1. Text Input
            // 2. List of character encodings
            //    ( build a dictionary )
            ReadTextToDecode();
            BuildDictionary();
            DecodeInput();

            Console.WriteLine(output);
        }
    }
}
