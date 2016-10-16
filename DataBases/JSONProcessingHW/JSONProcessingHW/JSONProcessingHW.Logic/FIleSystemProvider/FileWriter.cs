using System;
using System.IO;

using JSONProcessingHW.Logic.FIleSystemProvider.Contracts;

namespace JSONProcessingHW.Logic.FIleSystemProvider
{
    public class FileWriter : IFileWriter
    {
        public void WriteToFile(string fileName, string content)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            File.WriteAllText(fileName, content);
        }
    }
}
