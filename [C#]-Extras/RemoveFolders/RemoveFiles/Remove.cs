namespace RemoveFilesModels
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;

    public static class RemoveFiles
    {
        private static List<string> dirsFound = new List<string>();

        public static bool ClearList()
        {
            try
            {
                dirsFound.Clear();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

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
                    try
                    {
                        Directory.Delete(folder, true);
                    }
                    catch (Exception)
                    {

                        foldersNotFound.Add(folder);
                    }
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
