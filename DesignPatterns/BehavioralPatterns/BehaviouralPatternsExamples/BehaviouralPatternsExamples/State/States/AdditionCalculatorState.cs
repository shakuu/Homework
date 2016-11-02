using State.States.Contract;

namespace State.States
{
    public class AdditionCalculatorState : ICalculatorState
    {
        public decimal PerformOperation(decimal a, decimal b)
        {
            return a + b;
        }
    }
}
