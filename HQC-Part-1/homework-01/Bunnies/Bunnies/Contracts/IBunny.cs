namespace Bunnies.Contracts
{
    using Bunnies.Enums;

    public interface IBunny
    {
        int Age { get; set; }

        string Name { get; set; }

        FurType FurType { get; set; }

        void Introduce(IWriter writer);
    }
}
