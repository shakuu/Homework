using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03_Line_Numbers
{
    class LineNumbers
    {
        static void Main()
        {
            // Input FilePath - hard coded for testing
            var toParse = @"D:\GitHub\notfound.html"; // Console.ReadLine();
            var output = @"D:\GitHub\notfound-with-linenumbers.html"; // Console.ReadLine();

            // initialize the input/ output streams.
            var reader = new StreamReader(toParse);
            var writer = new StreamWriter(output, false, Encoding.UTF8);

            // Build the row number to insert
            var rowCounter = 1;
            var rowFormat = "{0} ";

            

            var curRow = reader.ReadLine();

            while (curRow != null)
            {
                var newRow = new StringBuilder();

                // Insert Line Number followed by empty space.
                newRow.Append(string.Format(rowFormat, rowCounter++));
                newRow.Append(curRow);

                // Insert original line content.
                writer.WriteLine(newRow.ToString());

                // Write to the new file.
                curRow = reader.ReadLine();
            }

            // close the streams
            reader.Close();
            writer.Close();
        }
    }
}
