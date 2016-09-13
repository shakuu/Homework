namespace _03_Porcupines.Engine.Contracts
{
    public interface IEngine
    {
        bool EvaluateNextCommand(string command);

        string GetResult();
    }
}
