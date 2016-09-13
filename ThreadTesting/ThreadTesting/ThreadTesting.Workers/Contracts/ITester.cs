namespace ThreadTesting.Workers.Contracts
{
    public interface ITester
    {
        bool? IsPassing { get; }

        string Value { get; }

        void RunTest();
    }
}
