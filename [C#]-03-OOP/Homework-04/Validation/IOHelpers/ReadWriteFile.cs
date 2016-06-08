
namespace Validation.IOHelpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal static class ReadWriteFile
    {
        internal static List<string> ReadForbiddenWordsFromFile(string filename)
        {
            var output = new List<string>();
            try
            {
                using (var reader = new StreamReader(filename))
                {
                    while (!reader.EndOfStream)
                    {
                        output.Add(reader.ReadLine());
                    }

                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            

            return output;
        }
    }
}
