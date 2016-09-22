namespace MatrixPath.Logic.UI.Contracts
{
    public interface IUserInterface
    {
        void PostMessage(string message);

        string AskForInput(string message);
    }
}
