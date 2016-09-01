using _03_Porcupines.Forests.Enums;

namespace _03_Porcupines.Forests.Contracts
{
    public interface IForestCell
    {
        ForestCellContentType ContentType { get; set; }

        int Points { get; set; }
    }
}
