
namespace RemoveFilesModels
{
    using System;
    using System.Linq;
    using System.Text;
    using System.IO;

    public static class RemoveFiles
    {
        private static StringBuilder testing = new StringBuilder();

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
                    Directory.Delete(dir, true);
                    testing.AppendLine(dir);
                }
                else
                {
                    Remove(dir);
                }
            }

            return testing.ToString();
        }

        private static bool CheckDir(string path)
        {
            var folders = path.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .Last();

            if (folders == "bin" || folders == "obj")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
