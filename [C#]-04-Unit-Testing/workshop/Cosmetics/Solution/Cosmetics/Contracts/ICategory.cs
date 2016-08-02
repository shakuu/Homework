namespace Cosmetics.Contracts
{
    internal interface ICategory
    {
        string Name { get; }

        void AddCosmetics(IProduct cosmetics);

        void RemoveCosmetics(IProduct cosmetics);

        string Print();
    }
}
