using System;

using JSONProcessingHW.Logic.FIleSystemProvider.Contracts;
using JSONProcessingHW.Logic.HtmlGenerator.Contracts;

namespace JSONProcessingHW.Logic.HtmlGenerator
{
    public class HtmlFileCreator : IHtmlFileCreator
    {
        private const string Template = @"<!DOCTYPE html>
                                           <html lang=""en"">

                                           <head>
                                               <meta charset = ""UTF-8"" >
                                               <title>{1}</title>
                                           </head>
                                           
                                           <body>
                                           {0}
                                           </body>
                                           </html> ";

        private readonly IFileWriter fileWriter;

        public HtmlFileCreator(IFileWriter fileWriter)
        {
            if (fileWriter == null)
            {
                throw new ArgumentNullException(nameof(fileWriter));
            }

            this.fileWriter = fileWriter;
        }

        public void CreateHtmlFile(string fileName, string title, string content)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var fileContent = string.Format(HtmlFileCreator.Template, content, title);
            this.fileWriter.WriteToFile(fileName, fileContent);
        }
    }
}
