namespace Events.Contracts
{
    public interface IEngine
    {
        string Log { get; }

        bool ExecuteNextCommand(string command);
    }
}
