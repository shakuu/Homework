
namespace PointAndMatrix.PathUtility
{
    using System;
    using System.Text;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using Point;

    public static class PathStorage
    {
        public static void SavePath(Path path, string pathName)
        {
            var pathFormat = "C:\\Users\\{0}\\Documents\\Paths\\{1}";
            var folderFormat = "C:\\Users\\{0}\\Documents\\Paths\\";
            var user = Environment.UserName;

            var fileName = pathName + ".txt";
            var filePath = string.Format(pathFormat, user, fileName);
            var folderName = string.Format(folderFormat, user);

            if (!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);

            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach (var point in path)
                {
                    writer.WriteLine(point.ToString());
                }
            }
        }
        public static Path ReadPath()
        {
            var output = new Path();

            var pathFormat = "C:\\Users\\{0}\\Documents\\Paths\\{1}";
            var folderFormat = "C:\\Users\\{0}\\Documents\\Paths\\";
            var user = Environment.UserName;

            var folder = string.Format(folderFormat, user);

            if (!Directory.Exists(folder)) throw new ArgumentException("Folder does not exist, no files to read from");

            #region Pick a File
            var allFiles = Directory.EnumerateFiles(folder);
            var fileNames = new List<string>();

            foreach (var file in allFiles)
            {
                var name = file.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                fileNames.Add(name[name.Length - 1]);
                Console.WriteLine("{0, 4}: {1}", fileNames.Count, fileNames[fileNames.Count - 1]);
            }

            Console.WriteLine("Select a File Index");
            var fileIndex = int.Parse(Console.ReadLine()) - 1;
            #endregion
            
            var pathToFile = string.Format(pathFormat, user, fileNames[fileIndex]);

            output = ReadFromFile(pathToFile);
            
            return output;
        }
        public static Path ReadPath(string fileName)
        {
            var output = new Path();

            var pathFormat = "C:\\Users\\{0}\\Documents\\Paths\\{1}";
            var user = Environment.UserName;

            var path = string.Format(pathFormat, user, fileName);

            if (File.Exists(path)) output = ReadFromFile(path);
            else throw new ArgumentException("File does not exist");

            return output;
        }
        private static Path ReadFromFile(string path)
        {
            var output = new Path();

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var coordinates = reader.ReadLine()
                        .Trim()
                        .Split(new[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    var pointToAdd = new Point3D(coordinates[0], coordinates[1], coordinates[2]);

                    output.AddPoint(pointToAdd);
                }
            }

            return output;
        }
    }
}
