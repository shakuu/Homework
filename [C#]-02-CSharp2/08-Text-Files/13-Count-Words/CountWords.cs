using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _13_Count_Words
{
    class CountWords
    {
        static void Main(string[] args)
        {
            // Format of each line in the new file
            // {current word}<emptyspeace>{count}
            var toWriteFormat = "{0, -8} | {1, 4}";

            // Input Files
            var toParseFile = @"D:\GitHub\Test-Files\12input.txt"; //Console.ReadLine();
            var toCountFile = @"D:\GitHub\Test-Files\12words.txt";//Console.ReadLine();

            var tempFile = @"D:\GitHub\Test-Files\temp.txt";

            // Extract the list of words to count.
            var toCountWordsList = ExtractWordsList(toCountFile);
            var toCountWordsCounters = new int[toCountWordsList.Count()]
                .Select(x => x = 0)
                .ToArray();

            // Count.
            using (var toParseFileReader = CreateInputStream(toParseFile))
            {
                // Read each line from the file and count the words in it
                while (!toParseFileReader.EndOfStream)
                {
                    // Count words
                    toCountWordsCounters = CountWordsInString(
                        toParseFileReader.ReadLine(),
                        toCountWordsCounters,
                        toCountWordsList.ToArray()
                        );
                }
            }

            // Write the results to file
            using (var tempFileWriter = CreateOutputStream(tempFile))
            {
                for (int wordIndex = 0; 
                         wordIndex < toCountWordsList.Count(); 
                         wordIndex++)
                {
                    tempFileWriter.WriteLine(
                        string.Format(
                            toWriteFormat,
                            toCountWordsList[wordIndex],
                            toCountWordsCounters[wordIndex])
                            );
                }
            }
        }

        static int[] CountWordsInString(
            string toParse,
            int[] wordCounters,
            params string[] toCountWords)
        {
            //var separators = " ,.!?:;!@#$%^&*()_-+=";

            foreach (var word in toCountWords)
            {
                var curWordIndex = toParse.IndexOf(word);

                while (curWordIndex >= 0)
                {
                    var isWord = false;

                    // Check if the word is surrounded by separators
                    // First word in the string.
                    if (curWordIndex == 0)
                    {
                        if (!char.IsLetterOrDigit(toParse[curWordIndex + word.Length]))
                        {
                            isWord = true;
                        }
                    }
                    // Last word in the string.
                    else if (curWordIndex + word.Length == toParse.Length)
                    {
                        if (!char.IsLetterOrDigit(toParse[curWordIndex - 1]))
                        {
                            isWord = true;
                        }
                    }
                    else if (!char.IsLetterOrDigit(toParse[curWordIndex - 1]) &&
                             !char.IsLetterOrDigit(toParse[curWordIndex + word.Length]))
                    {
                        isWord = true;
                    }

                    if (isWord)
                    {
                        wordCounters[Array.IndexOf(toCountWords, word)]++;
                        isWord = false;
                    }

                    // Find next occurance
                    curWordIndex = toParse.IndexOf(word, ++curWordIndex);
                }
            }

            return wordCounters;
        }

        static List<string> ExtractWordsList(string fileName)
        {
            var separators = " ,.!?:;!@#$%^&*()_-+=";

            var toReturn = new List<string>();

            using (var reader = CreateInputStream(fileName))
            {
                while (!reader.EndOfStream)
                {
                    toReturn.AddRange(
                        reader.ReadLine()
                            .Trim()
                            .Split(
                                separators.ToCharArray(),
                                StringSplitOptions.RemoveEmptyEntries)
                            .ToList()
                            );
                }
            }

            return toReturn;
        }

        static StreamReader CreateInputStream(string fileName)
        {
            StreamReader toReturnStream = null;

            try
            {
                toReturnStream = new StreamReader(fileName);
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

        static StreamWriter CreateOutputStream(string fileName)
        {
            StreamWriter toReturnStream = null;

            // Create File if it does not exist.
            if (!File.Exists(fileName))
            {
                var fileCreateNew = File.Create(fileName);
                fileCreateNew.Close(); // release the file to be used 
            }

            try
            {
                toReturnStream = new StreamWriter(fileName);
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
    }
}
