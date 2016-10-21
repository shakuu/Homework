using System.Collections.Generic;

namespace ADONET.Homework.Logic.ImageServices.Contracts
{
    public interface IImageService
    {
        void SaveImageToFile(byte[] imageData, string fileName);
    }
}
