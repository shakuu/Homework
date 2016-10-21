using System.Drawing;
using System.IO;

using ADONET.Homework.Logic.ImageServices.Contracts;

namespace ADONET.Homework.Logic.ImageServices
{
    public class ImageService : IImageService
    {
        private ImageConverter imageConverter;

        private ImageConverter ImageConverter
        {
            get
            {
                if (this.imageConverter == null)
                {
                    this.imageConverter = new ImageConverter();
                }

                return this.imageConverter;
            }
        }

        public void SaveImageToFile(byte[] imageData, string fileName)
        {
            var fileNameInfo = new FileInfo(fileName);
            var directoryExists = Directory.Exists(fileNameInfo.DirectoryName);
            if (!directoryExists)
            {
                Directory.CreateDirectory(fileNameInfo.DirectoryName);
            }
            
            var image = (Bitmap)(this.ImageConverter.ConvertFrom(imageData));
            image.Save(fileName);
        }
    }
}
