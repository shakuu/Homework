namespace FastAndFurious.ConsoleApplication.Engine.Contracts
{
    public interface IStrategyChainOfResponsibility
    {
        void SetNextStrategy(IStrategy strategy);
    }
}
