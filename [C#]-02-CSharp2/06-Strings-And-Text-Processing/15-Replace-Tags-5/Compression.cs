using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Replace_Tags_5
{
    class Compression
    {
        static void Main()
        {
            var readconsole = Console.In;

            var counter = 1;

            var compressedInput = new StringBuilder();

            var prevChar = Console.Read();

            var isTag = false;

            if (prevChar == '<')
            {
                isTag = true;
                compressedInput.Append((char)prevChar);
            }

            while (true)
            {
                int curChar = Console.Read();

                // Break on New Line
                if (curChar == 13)
                {
                    compressedInput.Append((char)prevChar);

                    if (counter > 1)
                    {
                        compressedInput.Append(counter);
                        compressedInput.Append('~');
                        counter = 1;
                    }
                    break;
                }

                if (curChar == (int)'<')
                {
                    isTag = true;

                    compressedInput.Append((char)prevChar);


                    if (counter > 1)
                    {
                        compressedInput.Append(counter);
                        compressedInput.Append('~');
                        counter = 1;
                    }

                    compressedInput.Append((char)curChar);
                    prevChar = curChar;
                    continue;
                }

                if (curChar == (int)'>')
                {
                    isTag = false;
                    prevChar = curChar;
                    continue;
                }

                if (isTag)
                {
                    compressedInput.Append((char)curChar);
                    continue;
                }

                if (curChar == prevChar)
                {
                    counter++;
                    continue;
                }
                else
                {
                    // Append the string
                    compressedInput.Append((char)prevChar);

                    if (counter > 1)
                    {
                        compressedInput.Append(counter);
                        compressedInput.Append('~');
                        counter = 1;
                    }

                    prevChar = curChar;
                }
            }

            Console.WriteLine(compressedInput);
        }

    }
}
