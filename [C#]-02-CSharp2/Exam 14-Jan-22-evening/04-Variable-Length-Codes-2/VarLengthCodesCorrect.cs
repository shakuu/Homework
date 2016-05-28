
namespace _04_Variable_Length_Codes_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class VarLengthCodesCorrect
    {
        // Input variables.
        static string[] input;
        static StringBuilder output;
        static Dictionary<string, char> codes;
        
        // INCORRECT INPUT PAD NUMBERS LEFT!!!
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
                .Select(x => x = x.PadLeft(8, '0'))
                .ToArray();
        }
        
        // Input Line 2: Number of lines
        // Input Line 3 to N : Codes
        static void BuildDictionary()

        {
            var encoding = Encoding.Unicode;

            codes = new Dictionary<string, char>();

            var linesOfCodes = int.Parse(Console.ReadLine());

            for (int line = 0; line < linesOfCodes; line++)
            {
                // Get each ASCII byte
                var bytes = encoding.GetBytes(Console.ReadLine());

                // Byte 1: Value
                var value = BitConverter.ToChar(bytes, 0);

                // Get Key length.
                var keyLen = new StringBuilder();
                for (int chr = 2; chr < bytes.Length; chr += 2) keyLen.Append(BitConverter.ToChar(bytes, chr));
                var keyLength = int.Parse(keyLen.ToString());

                // Build the key.
                var key = new StringBuilder();
                for (int length = 0; length < keyLength; length++) key.Append(1);

                // Add code to dictionary
                codes.Add(key.ToString(), value);
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
                            if (codes.ContainsKey(curCode.ToString()))
                            {
                                output.Append(codes[curCode.ToString()]);
                            }
                            // Check if Key exists ( exceptions )
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
