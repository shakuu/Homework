using _02_Kitty.Engine.Enums;

namespace _02_Kitty.Engine.Contracts
{
    public interface IPathCell
    {
        CellConentType ContentType { get; set; }

        bool IsOddPosition { get; set; }

        bool IsCollected { get; set; }
    }
}
