namespace Abstraction.Contracts
{
    public interface IRectangle : IFigure
    {
        double Width { get; set; }

        double Height { get; set; }
    }
}
