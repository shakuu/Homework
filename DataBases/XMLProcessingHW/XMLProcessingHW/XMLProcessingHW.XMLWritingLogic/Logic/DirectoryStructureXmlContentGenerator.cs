using System;
using System.Collections.Generic;
using System.IO;

using XMLProcessingHW.XMLWritingLogic.Contracts;

namespace XMLProcessingHW.XMLWritingLogic.Logic
{
    public class DirectoryStructureXmlContentGenerator : IXmlContentGenerator
    {
        private const string ElementNameDirectory = "directory";
        private const string ElementNameFile = "file";

        private readonly string rootDirectory;
        private readonly Func<string, string, IXmlContent> contentCreator;

        private ICollection<IXmlContent> generatedContent;

        public DirectoryStructureXmlContentGenerator(string rootDirectory, Func<string, string, IXmlContent> contentCreator)
        {
            if (string.IsNullOrEmpty(rootDirectory))
            {
                throw new ArgumentNullException(nameof(rootDirectory));
            }

            if (contentCreator == null)
            {
                throw new ArgumentNullException(nameof(contentCreator));
            }

            this.rootDirectory = rootDirectory;
            this.contentCreator = contentCreator;
        }

        public IEnumerable<IXmlContent> GeneratedContent
        {
            get
            {
                if (this.generatedContent == null)
                {
                    this.generatedContent = this.GenerateContent(this.rootDirectory);
                }

                var generatedContentToReturn = new LinkedList<IXmlContent>(this.generatedContent);
                return generatedContentToReturn;
            }
        }

        private ICollection<IXmlContent> GenerateContent(string rootDirectory)
        {
            throw new NotImplementedException();
        }

        private void ParseDirectory(string currentDirectory)
        {
            var directoryInfo = new DirectoryInfo(currentDirectory);

            var contentElementName = DirectoryStructureXmlContentGenerator.ElementNameDirectory;
            var contentElementText = directoryInfo.FullName;
            var content = this.contentCreator(contentElementName, contentElementText);
            this.generatedContent.Add(content);

            var subDirectories = directoryInfo.GetDirectories();
            foreach (var directory in subDirectories)
            {
                var directoryName = directory.FullName;
                this.ParseDirectory(directoryName);
            }
        }
    }
}
