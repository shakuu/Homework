using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _07_Replace_Sub_String
{
    class ReplaceSubstringWtemp
    {
        static void Main()
        {
            // Using a temp file.
            // Better Way ?

            var toReplace = "start";
            var replaceWith = "finish";

            var fileTemp = @"D:\GitHub\Test-Files\temp.txt";

            // File to parse and replace
            var fileInput = @"D:\GitHub\Test-Files\07input.txt";//Console.ReadLine();

            var reader = new StreamReader(fileInput);
            var writer = new StreamWriter(fileTemp, false, Encoding.UTF8);

            var curLine = reader.ReadLine();

            while (curLine != null)
            {
                // TODO: Proper replacing 
                curLine = curLine.Replace(toReplace, replaceWith);

                writer.WriteLine(curLine);

                curLine = reader.ReadLine();
            }

            reader.Close();
            writer.Close();

            //var fileName = fileInput
            //    .Substring(
            //        fileInput.LastIndexOf("\\"),
            //        fileInput.Length - fileInput.LastIndexOf("\\"));

            File.Delete(fileInput);
            File.Move(fileTemp, fileInput);
        }
    }
}
