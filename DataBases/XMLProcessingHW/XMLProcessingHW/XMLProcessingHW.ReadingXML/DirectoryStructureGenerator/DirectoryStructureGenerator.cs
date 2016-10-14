using System;
using System.IO;

using XMLProcessingHW.ReadingXML.DirectoryStructureGenerators.Contracts;

namespace XMLProcessingHW.ReadingXML.DirectoryStructureGenerators
{
    public class DirectoryStructureGenerator : IDirectoryStructureGenerator
    {
        private const string ElementNameDirectory = "directory";
        private const string ElementNameFile = "file";

        public void GenerateDirectoryStructure(string rootDirectory, IDirectoryStructureLogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (string.IsNullOrEmpty(rootDirectory))
            {
                throw new ArgumentNullException(nameof(rootDirectory));
            }

            if (!Directory.Exists(rootDirectory))
            {
                throw new DirectoryNotFoundException(rootDirectory);
            }

            using (logger)
            {
                this.ParseDirectory(rootDirectory, logger);
            }
        }

        private void ParseDirectory(string rootDirectory, IDirectoryStructureLogger logger)
        {
            var directoryInfo = new DirectoryInfo(rootDirectory);

            logger.LogElement(DirectoryStructureGenerator.ElementNameDirectory, directoryInfo.FullName, true);

            var subDirectories = directoryInfo.GetDirectories();
            foreach (var directory in subDirectories)
            {
                this.ParseDirectory(directory.FullName, logger);
            }

            var files = directoryInfo.GetFiles();
            foreach (var file in files)
            {
                logger.LogElement(DirectoryStructureGenerator.ElementNameFile, file.FullName);
            }

            logger.EndScope();
        }
    }
}
