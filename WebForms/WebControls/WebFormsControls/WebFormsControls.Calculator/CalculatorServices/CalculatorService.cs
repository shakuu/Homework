using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsControls.Calculator.CalculatorServices.Contracts;

namespace WebFormsControls.Calculator.CalculatorServices
{
    public class CalculatorService : ICalculatorService
    {
        private string previousValue = string.Empty;
        private string currentValue = string.Empty;
        private string displayValue = string.Empty;

        private string queuedOperation = string.Empty;

        public string HandleInput(string input)
        {
            var firstChar = input[0];

            var isDigit = char.IsDigit(firstChar);
            if (isDigit)
            {
                return this.HandleDigit(currentValue, firstChar);
            }
            else
            {
                return this.HandleOperation(this.currentValue, this.previousValue, firstChar);
            }
        }

        private string HandleDigit(string currentValue, char digit)
        {
            this.currentValue = currentValue + digit;
            return this.currentValue;
        }

        private string HandleOperation(string currentValue, string previousValue, char operation)
        {
            if (operation == 'c')
            {
                this.previousValue = string.Empty;
                this.currentValue = string.Empty;
                this.queuedOperation = string.Empty;
                return "0";
            }

            if (currentValue == string.Empty && operation == '-')
            {
                this.previousValue = "0";
                this.queuedOperation = operation.ToString();
                return "0";
            }

            if (previousValue == string.Empty)
            {
                this.previousValue = this.currentValue;
                this.currentValue = string.Empty;
                this.queuedOperation = operation.ToString();
                return this.previousValue;
            }

            if (operation == 's' && this.currentValue != string.Empty)
            {
                var value = double.Parse(this.currentValue);
                var sqrt = Math.Sqrt(value);
                return sqrt.ToString();
            }

            if (this.queuedOperation == string.Empty && this.previousValue == string.Empty)
            {
                this.queuedOperation = operation.ToString();
                this.previousValue = this.currentValue;
                return previousValue;
            }

            decimal prev;
            decimal next;
            try
            {
                prev = decimal.Parse(this.previousValue);
                next = decimal.Parse(this.currentValue);
            }
            catch (Exception)
            {
                return "0";
            }

            decimal result = 0;
            switch (queuedOperation[0])
            {
                case '+':
                    result = prev + next;
                    break;
                case '-':
                    result = prev - next;
                    break;
                case '*':
                    result = prev * next;
                    break;
                case '/':
                    result = prev / next;
                    break;
                default:
                    result = 0;
                    break;
            }

            this.previousValue = result.ToString();
            this.currentValue = string.Empty;
            this.queuedOperation = operation.ToString();

            return result.ToString();
        }
    }
}
