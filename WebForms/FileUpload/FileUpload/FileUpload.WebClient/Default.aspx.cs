using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUpload.WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        public void OnUpload(object sender, EventArgs e)
        {
            if (this.ZipFileUpload.HasFile)
            {
                var zip = ZipFile.Read(this.ZipFileUpload.FileContent);
                foreach (var entry in zip.Entries)
                {
                    var test = entry;
                    using (var stream = new MemoryStream())
                    {
                        entry.Extract(stream);
                        var data = stream.GetBuffer();

                    }
                }
            }
        }
    }
}