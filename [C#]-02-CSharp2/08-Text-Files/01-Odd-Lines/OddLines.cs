using System;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Text;

namespace _01_Odd_Lines
{
    class OddLines
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var testFile = @"D:\GitHub\notfound.html"; // Console.ReadLine();

            // 
            using (var stream = new StreamReader(testFile))
            {
                var currentLine = stream.ReadLine();
                var counter = 0;

                do
                {
                    if ((counter++ & 1) != 0)
                    {
                        Console.WriteLine(currentLine);
                    }

                    currentLine = stream.ReadLine();

                } while (currentLine != null);
            }
        }
    }
}
