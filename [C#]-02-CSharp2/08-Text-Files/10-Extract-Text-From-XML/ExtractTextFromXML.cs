using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _10_Extract_Text_From_XML
{
    class ExtractTextFromXML
    {
        static char tagOpen = '<';
        static char tagClose = '>';

        static void Main()
        {


            // Case opentag -> remove
            // Case letter -> keep

            // Get file path
            var fileToParse = @"D:\GitHub\Test-Files\10input.xml";//Console.ReadLine();

            var fileOutput = @"D:\GitHub\Test-Files\10output.txt";

            var reader = new StreamReader(fileToParse);
            var writer = new StreamWriter(fileOutput);

            while (!reader.EndOfStream)
            {
                // Read a line.
                var toAdd = reader.ReadLine();
                // Extract text.
                toAdd = ExtractTextAgain(toAdd);
                // Write to output.
                writer.WriteLine(toAdd);
            }

            reader.Close();
            writer.Close();
        }

        // Extract by removing tags.
        static string ExtractText(string curLine)
        {
            var line = new StringBuilder();

            while (curLine.Length > 0)
            {
                // Case 1: < opening tag
                if (curLine[0] == tagOpen)
                {
                    curLine = curLine.Remove(0, curLine.IndexOf(tagClose) + 1);
                    continue;
                }

                // Case 2: letter
                if (char.IsLetterOrDigit(curLine[0]))
                {
                    var text = curLine.Substring(0, curLine.IndexOf(tagOpen));
                    curLine = curLine.Remove(0, curLine.IndexOf(tagOpen));
                    line.Append(text);
                    line.Append(" ");
                    continue;
                }
            }

            return line.ToString().Trim();
        }

        // Extract by checking between closing tags.
        static string ExtractTextAgain(string curLine)
        {
            var toReturn = new StringBuilder();
            var toRead = false;

            for (int curElement = 0; 
                     curElement < curLine.Length - 1; 
                     curElement++)
            {
                if (curLine[curElement] == tagClose &&
                    curLine[curElement + 1] != tagOpen)
                {
                    toRead = true;
                    continue;
                }

                if (toRead && curLine[curElement] == tagOpen)
                {
                    toReturn.Append(" ");
                    toRead = false;
                    continue;
                }

                if (toRead)
                {
                    toReturn.Append(curLine[curElement]);
                    continue;
                }
            }

            return toReturn.ToString();
        }
    }
}
