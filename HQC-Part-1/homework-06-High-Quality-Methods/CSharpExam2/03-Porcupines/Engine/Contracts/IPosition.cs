using _03_Porcupines.Engine.Enums;

namespace _03_Porcupines.Engine.Contracts
{
    public interface IPosition
    {
        int Row { get; set; }

        int Column { get; set; }

        IPosition Add(IPosition amount);
    }
}
