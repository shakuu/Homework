namespace Cosmetics.Contracts
{
    using Cosmetics.Common;

    public interface IShampoo : IProduct
    {
        uint Milliliters { get; set; }

        UsageType Usage { get; set; }
    }
}