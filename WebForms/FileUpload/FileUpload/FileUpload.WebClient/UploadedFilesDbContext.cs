using System.Data.Entity;

namespace FileUpload.WebClient
{
    public class UploadedFilesDbContext : DbContext
    {
        public UploadedFilesDbContext()
            : base("name=UploadedFilesDb")
        {
        }

        public virtual DbSet<UploadedFile> UploadedFiles { get; set; }
    }
}
