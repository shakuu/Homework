namespace Dealership.Common.Contracts
{
    public interface IIOProvider
    {
        void WriteLine(string message);

        void Write(string message);

        string ReadLine();
    }
}
