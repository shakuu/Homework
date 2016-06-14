namespace RemoveFilesModels
{
    using System;
    using System.Linq;
    using System.Text;
    using System.IO;

    public static class RemoveFiles
    {
        private static StringBuilder listDirsDeleted
            = new StringBuilder();

        public static string Remove(string path)
        {
            var dirs = Directory.GetDirectories(path);

            if (dirs == null)
            {
                return string.Empty;
            }

            foreach (var dir in dirs)
            {
                if (CheckDir(dir))
                {
                    // delete
                    //Directory.Delete(dir, true);
                    listDirsDeleted.AppendLine(dir);
                }
                else
                {
                    Remove(dir);
                }
            }

            return listDirsDeleted.ToString();
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
