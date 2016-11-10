namespace FastAndFurious.ConsoleApplication.Engine.Contracts
{
    public interface IStrategyProvider
    {
        IStrategy GetStrategy(string command);
    }
}
