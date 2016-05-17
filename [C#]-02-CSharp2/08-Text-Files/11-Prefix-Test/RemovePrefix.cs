using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _11_Prefix_Test
{
    class RemovePrefixFromFile
    {
        static void Main()
        {
            var toRemove = "test";

            // Input File
            var fileToParse = @"D:\GitHub\Test-Files\11input.txt"; //Console.ReadLine();

            var fileTemp = @"D:\GitHub\Test-Files\temp.txt";

            var reader = new StreamReader(fileToParse);
            var writer = new StreamWriter(fileTemp);

            while (!reader.EndOfStream)
            {
                writer.WriteLine(
                    RemovePrefix(
                        reader.ReadLine(),
                        toRemove)
                        );
            }

            reader.Close();
            writer.Close();

            File.Delete(fileToParse);
            File.Move(fileTemp, fileToParse);
        }

        static string RemovePrefix(string curLine, string toRomove)
        {
            var curPosition = curLine.IndexOf(toRomove);

            while (curPosition >= 0)
            {
                // Check if it is a prefix
                // and remove if it is.
                try
                {
                    if (curLine[curPosition + toRomove.Length] == '_')
                    {
                        curLine = curLine.Remove(curPosition, toRomove.Length + 1);
                    }
                    else if (char.IsLetterOrDigit(curLine[curPosition + toRomove.Length]))
                    {
                        curLine = curLine.Remove(curPosition, toRomove.Length);
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    // Checking last word on the row
                    // not a prefix.
                    break;
                }
                
                // Find next occurance
                curPosition = curLine.IndexOf(
                    toRomove,
                    curPosition + 1);
            }

            return curLine;
        }
    }
}
