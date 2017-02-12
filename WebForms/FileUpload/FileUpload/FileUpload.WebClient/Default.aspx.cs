using System;
using System.IO;

using Ionic.Zip;

namespace FileUpload.WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        public void OnUpload(object sender, EventArgs e)
        {
            if (this.ZipFileUpload.HasFile)
            {
                var db = new UploadedFilesDbContext();
                var filesCount = 0;

                var zip = ZipFile.Read(this.ZipFileUpload.FileContent);
                foreach (var entry in zip.Entries)
                {
                    var extension = Path.GetExtension(entry.FileName);
                    if (extension != ".txt")
                    {
                        continue;
                    }

                    using (var stream = new MemoryStream())
                    {
                        entry.Extract(stream);
                        var data = stream.GetBuffer();

                        var file = new UploadedFile();
                        file.Data = data;
                        file.FileName = entry.FileName;

                        db.UploadedFiles.Add(file);
                        filesCount++;
                    }
                }

                db.SaveChangesAsync();

                this.FilesCount.InnerText = filesCount.ToString();
            }
        }
    }
}