namespace Cosmetics.Contracts
{
    using Cosmetics.Common;

    public interface IShampoo : IProduct
    {
        uint Milliliters { get; }

        UsageType Usage { get; }
    }
}