namespace RemoveFilesModels
{
    using System;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Collections.Generic;

    public static class RemoveFiles
    {
        private static StringBuilder listDirsDeleted
            = new StringBuilder();

        private static List<string> dirsFound = new List<string>();

        public static List<string> FindObjBinDirectories(string path)
        {
            var dirs = Directory.GetDirectories(path);

            if (dirs == null)
            {
                return dirsFound;
            }

            foreach (var dir in dirs)
            {
                if (CheckDir(dir))
                {
                    // delete
                    //Directory.Delete(dir, true);
                    dirsFound.Add(dir);
                }
                else
                {
                    FindObjBinDirectories(dir);
                }
            }

            return dirsFound;
        }

        public static List<string> RemoveFolder(List<string> folders)
        {
            var foldersNotFound = new List<string>();

            foreach (var folder in folders)
            {
                if (Directory.Exists(folder))
                {
                    Directory.Delete(folder, true);
                }
                else
                {
                    foldersNotFound.Add(folder);
                }
            }

            return foldersNotFound;
        }

        private static bool CheckDir(string path)
        {
            var folders = path
                .Split(
                    new[] { '\\' },
                    StringSplitOptions.RemoveEmptyEntries)
                .Last();

            return (folders == "bin" || folders == "obj");
        }
    }
}
