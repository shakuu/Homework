namespace ThreadTesting.Workers.Contracts
{
    public interface ITester
    {
        bool? IsPassing { get; }

        void RunTest();
    }
}
