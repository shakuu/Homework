using System;

using WebFormsControls.Calculator.CalculatorServices;

namespace WebFormsControls.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var calculator = new CalculatorService();

            while (true)
            {
                var nextCommand = Console.ReadLine();

                var output = calculator.HandleInput(nextCommand);

                Console.WriteLine(output);
            }
        }
    }
}
