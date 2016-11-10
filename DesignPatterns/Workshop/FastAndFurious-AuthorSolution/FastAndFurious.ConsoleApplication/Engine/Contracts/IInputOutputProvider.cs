namespace FastAndFurious.ConsoleApplication.Engine.Contracts
{
    public interface IInputOutputProvider
    {
        void WriteLine(string message);

        string ReadLine();
    }
}
