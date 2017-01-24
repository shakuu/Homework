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
                var result = this.HandleDigit(currentValue, firstChar);
                this.currentValue = result;
            }
            else
            {
                this.HandleOperation(this.currentValue, this.previousValue, firstChar);
            }

            return currentValue;
        }

        private string HandleDigit(string currentValue, char digit)
        {
            var result = currentValue + digit;
            return result;
        }

        private string HandleOperation(string currentValue, string previousValue, char operation)
        {
            if (operation == 'c')
            {
                this.previousValue = string.Empty;
                this.currentValue = string.Empty;
                this.queuedOperation = string.Empty;
                return string.Empty;
            }

            if (previousValue == string.Empty && operation == '-')
            {
                this.previousValue = "0";
                this.queuedOperation = operation.ToString();
                return string.Empty;
            }

            if (previousValue == string.Empty)
            {
                this.previousValue = this.currentValue;
                this.queuedOperation = operation.ToString();
                return string.Empty;
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
                return string.Empty;
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
