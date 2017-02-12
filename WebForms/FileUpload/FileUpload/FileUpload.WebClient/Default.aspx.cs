using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
                var filesList = new List<UploadedFile>();

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
                        file.Content = Encoding.UTF8.GetString(data);

                        db.UploadedFiles.Add(file);
                        filesList.Add(file);
                    }
                }

                db.SaveChangesAsync();

                this.FilesCount.InnerText = string.Format("Uploaded {0} files.", filesList.Count.ToString());
                this.UploadedFiles.DataSource = filesList;
                this.UploadedFiles.DataBind();
            }
        }
    }
}