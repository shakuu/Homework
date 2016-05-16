using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _04_Compare_Text_Files
{
    class CompareTextFiles
    {
        static void Main()
        {
            // Get paths to the 2 files to compare.
            // Hardcode for testing.
            var inputFileA = @"D:\GitHub\notfound.html"; //Console.ReadLine();
            var inputFileB = @"D:\GitHub\notfound-with-linenumbers.html"; //Console.ReadLine();

            // Input streams for both files.
            var readerFileA = new StreamReader(inputFileA);
            var readerFileB = new StreamReader(inputFileB);

            // Read row 1 of each.
            var rowFileA = readerFileA.ReadLine();
            var rowFileB = readerFileB.ReadLine();

            // Counters for input.
            var equalCounter = 0;
            var differentCounter = 0;

            while (rowFileA != null && rowFileB != null)
            {
                if (rowFileA == rowFileB)
                {
                    equalCounter++;
                }
                else
                {
                    differentCounter++;
                }

                // Read next line. ( or infiloop )
                rowFileA = readerFileA.ReadLine();
                rowFileB = readerFileB.ReadLine();
            }

            // Remember to close the streams.
            readerFileA.Close();
            readerFileB.Close();

            Console.WriteLine($"Equal Rows: {equalCounter}\nDifferent Rows: {differentCounter}");
        }
    }
}
