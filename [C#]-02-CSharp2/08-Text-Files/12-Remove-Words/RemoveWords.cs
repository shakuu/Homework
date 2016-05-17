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
            var toParseFile = Console.ReadLine();
            var toRemoveFile = Console.ReadLine();

            var tempFile = @"temp.txt";

            // Create Strem for the file containing 
            // the text to parse.
            var toParseReader = CreateStreamReader(tempFile);

            // Create an output stream for the temp file
            var tempFileWriter = CreateStreamWriter(tempFile);

            // Create the list of words to remove
            var toRemoveWordsList = GetWordsToRemove(toRemoveFile);

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

            var toRemoveReader = CreateStreamReader(filePath);

            toReturnList = toRemoveReader
                .ReadToEnd()
                .Trim()
                .Split()
                .ToList();

            return toReturnList;
        }

        // Create output stream helper method
        static StreamWriter CreateStreamWriter(string filePath)
        {
            StreamWriter toReturnStream = null;

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
