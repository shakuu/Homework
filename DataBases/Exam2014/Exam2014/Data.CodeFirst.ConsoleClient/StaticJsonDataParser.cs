using System.Collections.Generic;
using System.IO;
using System.Linq;

using Data.CodeFirst.DbContexts;
using Data.CodeFirst.Models;

using Newtonsoft.Json;

namespace Data.CodeFirst.ConsoleClient
{
    public class StaticJsonDataParser
    {
        private static DealershipsContext GetContext()
        {
            var context = new DealershipsContext();
            return context;
        }

        public static void ParseJsonData()
        {
            var files = StaticJsonDataParser.GetFilenamesList();
            foreach (var file in files)
            {
                var content = File.ReadAllText(file.FullName);
                var parsed = JsonConvert.DeserializeObject<List<Car>>(content);

                var context = StaticJsonDataParser.GetContext();
                var parsedCount = parsed.Count;
                for (int i = 0; i < parsedCount; i++)
                {
                    context.Cars.Add(parsed[i]);

                    if (i % 50 == 0)
                    {
                        context.SaveChanges();
                        context = StaticJsonDataParser.GetContext();
                    }
                }

                context.SaveChanges();
            }
        }

        private static IEnumerable<FileInfo> GetFilenamesList()
        {
            var directory = @"../../../Data.Json.Files";
            var directoryInfo = new DirectoryInfo(directory);

            var filesList = directoryInfo.GetFiles().ToList();
            for (int i = 0; i < filesList.Count; i++)
            {
                var fileName = filesList[i];

                var isValid = StaticJsonDataParser.IsValidFileName(fileName);
                if (!isValid)
                {
                    filesList.Remove(fileName);
                    i--;
                }
            }

            return filesList;
        }

        private static bool IsValidFileName(FileInfo file)
        {
            var fileName = file.Name;
            var fileNameWords = fileName.Split('.');

            // data.number.json
            if (fileNameWords.Length != 3)
            {
                return false;
            }

            int result;
            var validNumberWord = int.TryParse(fileNameWords[1], out result);
            var validFirstWord = fileNameWords[0] == "data";
            var validLastWord = fileNameWords[2] == "json";

            var isValidName = validFirstWord && validNumberWord && validLastWord;

            return isValidName;
        }
    }
}
