using State.States.Contract;

namespace State
{
    public class Calculator
    {
        public ICalculatorState State { get; set; }

        public decimal Calculate(decimal a, decimal b)
        {
            return this.State.PerformOperation(a, b);
        }
    }
}
