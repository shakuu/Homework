using _03_Porcupines.Forests.Enums;

namespace _03_Porcupines.Forests.Contracts
{
    public interface IForestCellFactory
    {
        IForestCell CreateForestCell(ForestCellContentType contentType, int points = 0);
    }
}
