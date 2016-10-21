using System.Drawing;
using System.IO;

using ADONET.Homework.Logic.ImageServices.Contracts;

namespace ADONET.Homework.Logic.ImageServices
{
    public class ImageService : IImageService
    {
        public void SaveImageToFile(byte[] imageData, string fileName)
        {
            var info = new FileInfo(fileName);

            var directoryExists = Directory.Exists(info.DirectoryName);
            if (!directoryExists)
            {
                Directory.CreateDirectory(info.DirectoryName);
            }

            Image x = (Bitmap)((new ImageConverter()).ConvertFrom(imageData));
            x.Save(fileName);
        }
    }
}
