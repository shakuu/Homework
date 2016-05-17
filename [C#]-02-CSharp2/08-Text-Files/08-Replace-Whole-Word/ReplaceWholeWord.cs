using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _08_Replace_Whole_Word
{
    class ReplaceWholeWord
    {
        static void Main()
        {
            // Using a temp file.
            // Better Way ?

            var separators = " .,?!-:;@#$%^&*()_+=\"\"\\/*'";

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
                curLine = ReplaceWord(
                    curLine, 
                    toReplace, 
                    replaceWith, 
                    separators);

                writer.WriteLine(curLine);

                curLine = reader.ReadLine();
            }

            reader.Close();
            writer.Close();

            // Do NOT delete the input file for testing.
            File.Delete(fileInput);
            File.Move(fileTemp, fileInput);
        }

        static string ReplaceWord(string curLine, 
                                  string toReplace, 
                                  string replaceWith,
                                  string separators)
        {
            // Get the first index of the word to replace.
            var curIndex = curLine.IndexOf(toReplace);

            // If index is negative, then word is not in the string.
            while (curIndex >= 0)
            {
                // Possible exception [0-1]
                try
                {
                    if ((separators.Contains(curLine[curIndex - 1]) &&
                     separators.Contains(curLine[curIndex + toReplace.Length])))
                    {
                        curLine = curLine.Remove(curIndex, toReplace.Length);
                        curLine = curLine.Insert(curIndex, replaceWith);
                    }
                }
                // If the first check is out of range 
                catch (System.IndexOutOfRangeException)
                {
                    try
                    {
                        if (separators.Contains(curLine[curIndex + toReplace.Length]))
                        {
                            curLine = curLine.Remove(curIndex, toReplace.Length);
                            curLine = curLine.Insert(curIndex, replaceWith);
                        }
                    }
                    // If both checks are out of range, then only word in string
                    catch (System.IndexOutOfRangeException)
                    {
                        curLine = curLine.Remove(curIndex, toReplace.Length);
                        curLine = curLine.Insert(curIndex, replaceWith);
                    }
                }
                

                // Search for more occurances of toReplace in the remainding string.
                curIndex = curLine.IndexOf(toReplace, curIndex + 1);
            }

            return curLine;
        }
    }
}
