namespace Bunnies.Contracts
{
    public interface IWriter
    {
        void Write(string message);

        void WriteLine(string message);
    }
}
