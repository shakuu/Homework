using System.IO;

namespace JSONProcessingHW.Logic.HtmlGenerator
{
    public class HtmlFileCreator
    {
        private static string Template = @"<!DOCTYPE html>
                                           <html lang=""en"">

                                           <head>
                                               <meta charset = ""UTF-8"" >
                                               <title> {1} </title>
                                           </head>
                                           
                                           <body>
                                           {0}
                                           </body>
                                           </html> ";

        public void CreateHtmlFile(string fileName,string title, string content)
        {
            var fileContent = string.Format(HtmlFileCreator.Template, content, title);
            File.WriteAllText(fileName, fileContent);
        }
    }
}
