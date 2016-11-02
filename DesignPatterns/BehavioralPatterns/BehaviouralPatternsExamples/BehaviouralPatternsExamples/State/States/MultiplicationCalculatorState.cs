using State.States.Contract;

namespace State.States
{
    public class MultiplicationCalculatorState : ICalculatorState
    {
        public decimal PerformOperation(decimal a, decimal b)
        {
            return a * b;
        }
    }
}
