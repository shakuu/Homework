using State.States;

namespace State
{
    public class Startup
    {
        public static void Main()
        {
            var calculator = new Calculator();

            var addition = new AdditionCalculatorState();
            var multiplication = new MultiplicationCalculatorState();

            calculator.State = addition;
            System.Console.WriteLine(calculator.Calculate(1, 1));

            calculator.State = multiplication;
            System.Console.WriteLine(calculator.Calculate(1, 1));
        }
    }
}
