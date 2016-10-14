using System;
using System.Collections.Generic;

using XMLProcessingHW.XMLWritingLogic.Contracts;

namespace XMLProcessingHW.XMLWritingLogic.Logic
{
    public class DirectoryStructureXmlContentGenerator : IXmlContentGenerator
    {
        private readonly string rootDirectory;

        private IEnumerable<IXmlContent> generatedContent;

        public DirectoryStructureXmlContentGenerator(string rootDirectory)
        {
            if (string.IsNullOrEmpty(rootDirectory))
            {
                throw new ArgumentNullException(nameof(rootDirectory));
            }

            this.rootDirectory = rootDirectory;
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

        private IEnumerable<IXmlContent> GenerateContent(string rootDirectory)
        {
            throw new NotImplementedException();
        }
    }
}
