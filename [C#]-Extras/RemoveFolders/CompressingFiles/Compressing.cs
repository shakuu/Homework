namespace CompressingFiles
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public static class Compressing
    {
        public static bool CompressFolder(string path)
        {
            var newPath = path + ".zip";

            if (File.Exists(newPath))
            {
                File.Delete(newPath);
            }

            try
            {
                ZipFile.CreateFromDirectory(path, newPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
