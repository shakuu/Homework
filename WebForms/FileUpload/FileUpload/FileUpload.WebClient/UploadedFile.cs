using System;

namespace FileUpload.WebClient
{
    public class UploadedFile
    {
        public UploadedFile()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public byte[] Data { get; set; }

        public string FileName { get; set; }
    }
}