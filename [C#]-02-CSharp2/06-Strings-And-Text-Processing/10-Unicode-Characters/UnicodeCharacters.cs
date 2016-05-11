using System;
using System.Text;

namespace _10_Unicode_Characters
{
    class UnicodeCharacters
    {
        static void Main()
        {
            var inputString = Console.ReadLine();

            var outputString = new StringBuilder();

            // In HEX 
            var UnicodeFormat = "\\u{0:X4}";
            
            foreach (var letter in inputString)
            {
                outputString.Append(
                    string.Format(
                        UnicodeFormat, 
                        (int)letter));
            }

            Console.WriteLine(outputString);
        }
    }
}
