using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _12_Remove_Words
{
    class RemoveWords
    {
        static void Main()
        {
            // TODO:
            // 1. Check for null streams.

            // Input files
            var toParseFile = @"D:\GitHub\Test-Files\12input.txt"; //Console.ReadLine();
            var toRemoveFile = @"D:\GitHub\Test-Files\12words.txt";//Console.ReadLine();

            var tempFile = @"D:\GitHub\Test-Files\temp.txt";

            // Create Strem for the file containing 
            // the text to parse.
            var toParseReader = CreateStreamReader(toParseFile);

            // Create an output stream for the temp file
            var tempFileWriter = CreateStreamWriter(tempFile);

            // Create the list of words to remove
            var toRemoveWordsList = GetWordsToRemove(toRemoveFile);

            // Read each line of the input file to parse
            // and remove all words as required.
            while (!toParseReader.EndOfStream)
            {
                // Read a line,
                // parse it, 
                // write the result in a new file.
                tempFileWriter.WriteLine(
                    RemoveWordsFromLine(
                        toParseReader.ReadLine(),
                        toRemoveWordsList.ToArray())
                        );
            }

            toParseReader.Close();
            tempFileWriter.Close();

            //File.Delete(toParseFile);
            //File.Move(tempFile, toParseFile);
        }

        // Remove Words TODO: INDEX OUT OF RANGE EXCEPTION
        static string RemoveWordsFromLine(
            string toParseLine,
            params string[] toRemoveWords)
        {
            var separators = " ,.!?:;!@#$%^&*()_-+=";

            foreach (var word in toRemoveWords)
            {
                // Get the first index of the current word.
                var curWordIndex = toParseLine.IndexOf(word);

                // -1 if the string does not contain the current word.
                while (curWordIndex >= 0)
                {
                    // helper variable
                    var toRemove = false;

                    // Check if the word is surrounded by separators
                    // First word in the string.
                    if (curWordIndex == 0)
                    {
                        if (separators.Contains(toParseLine[curWordIndex + word.Length]))
                        {
                            toRemove = true;
                        }
                    }
                    // Last word in the string.
                    else if (curWordIndex + word.Length == toParseLine.Length)
                    {
                        if (separators.Contains(toParseLine[curWordIndex - 1]))
                        {
                            toRemove = true;
                        }
                    }
                    else if (separators.Contains(toParseLine[curWordIndex - 1]) &&
                             separators.Contains(toParseLine[curWordIndex + word.Length]))
                    {
                        toRemove = true;
                    }

                    // Remove.
                    if (toRemove)
                    {
                        toParseLine = toParseLine.Remove(curWordIndex, word.Length);
                        toRemove = false;
                    }

                    // Search again
                    // Stop searching if at the end of the string.
                    if (++curWordIndex >= toParseLine.Length)
                    {
                        break;
                    }

                    curWordIndex = toParseLine.IndexOf(word, ++curWordIndex);
                }
            }
            
            return toParseLine.Trim();
        }

        // Extract the list of words to remove.
        // TODO: Check for empty List
        static List<string> GetWordsToRemove(string filePath)
        {
            // Create a stream for the file containg 
            // the words to remove.
            // Then the entire contents of the file
            // and split them into a list to return.
            // Check for all words at the same time.
            var toReturnList = new List<string>();

            var separators = " ,.!?:;!@#$%^&*()_-+=";

            var toRemoveReader = CreateStreamReader(filePath);

            while (!toRemoveReader.EndOfStream)
            {
                toReturnList.AddRange(
                    toRemoveReader.ReadLine()
                        .Trim()
                        .Split(
                            separators.ToCharArray(),
                            StringSplitOptions.RemoveEmptyEntries)
                        .ToList());
            }

            return toReturnList;
        }

        // Create output stream helper method
        static StreamWriter CreateStreamWriter(string filePath)
        {
            StreamWriter toReturnStream = null;

            // Create File if it does not exist.
            if (!File.Exists(filePath))
            {
                var fileCreateNew = File.Create(filePath, 32, FileOptions.None);
                fileCreateNew.Close(); // release the file to be used 
            }

            try
            {
                toReturnStream = new StreamWriter(filePath);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return toReturnStream;
        }

        // Create input stream helper method
        static StreamReader CreateStreamReader(string filePath)
        {
            StreamReader toReturnStream = null;

            try
            {
                toReturnStream = new StreamReader(filePath);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return toReturnStream;
        }

    }
}
