
namespace Validation.IOHelpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    internal static class ReadWriteFile
    {
        internal static List<string> ReadForbiddenWordsFromFile()
        {
            var output = new List<string>();
            var filename = GetDocumentsPath();

            if (!File.Exists(filename))
            {
                DownloadForbidenWords();
            }

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

        internal static void DownloadForbidenWords()
        {
            // Link to my google drive with Forbidden.txt
            // (contains forbidden word for validation) 
            var url = "https://docs.google.com/uc?authuser=0&id=0B8ljp3Uug64VUVRMUl9IUWZLcGc&export=download";
            var path = GetDocumentsPath();

            using (var client = new WebClient())
            {
                client.DownloadFile(url, path);
            }
        }

        private static string GetDocumentsPath()
        {
            var path = "C:\\Users\\{0}\\Documents\\Forbidden.txt";
            var user = Environment.UserName;
            return string.Format(path, user);
        }
    }
}
