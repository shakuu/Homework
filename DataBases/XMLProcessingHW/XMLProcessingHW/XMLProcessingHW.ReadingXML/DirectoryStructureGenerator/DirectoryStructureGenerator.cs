using System.IO;

using XMLProcessingHW.ReadingXML.DirectoryStructureGenerators.Contracts;

namespace XMLProcessingHW.ReadingXML.DirectoryStructureGenerators
{
    public class DirectoryStructureGenerator : IDirectoryStructureGenerator
    {
        private const string Directory = "directory";
        private const string File = "file";

        public void GenerateDirectoryStructure(string rootDirectory, IDirectoryStructureLogger logger)
        {
            using (logger)
            {
                this.ParseDirectory(rootDirectory, logger);
            }
        }

        private void ParseDirectory(string rootDirectory, IDirectoryStructureLogger logger)
        {
            var directoryInfo = new DirectoryInfo(rootDirectory);

            logger.LogElement(DirectoryStructureGenerator.Directory, directoryInfo.FullName, true);

            var subDirectories = directoryInfo.GetDirectories();
            foreach (var directory in subDirectories)
            {
                this.ParseDirectory(directory.FullName, logger);
            }

            var files = directoryInfo.GetFiles();
            foreach (var file in files)
            {
                logger.LogElement(DirectoryStructureGenerator.File, file.FullName);
            }

            logger.EndScope();
        }
    }
}
