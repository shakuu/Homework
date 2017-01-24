namespace WebFormsControls.Calculator.CalculatorServices.Contracts
{
    public interface ICalculatorService
    {
        string CurrentValue { get; }

        string PreviousValue { get; }

        string EnqueuedOperation { get; }

        string HandleInput(string input);

        void RestoreState(string currentValue, string previousValue, string enqueuedOperation);
    }
}
