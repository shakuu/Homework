namespace FastAndFurious.ConsoleApplication.Engine.Contracts
{
    public interface IStrategyChainOfResponsibility : IStrategy
    {
        void SetNextStrategy(IStrategy strategy);
    }
}
