using System;

using WebFormsControls.Calculator.CalculatorServices.Contracts;

namespace WebFormsControls.Calculator.CalculatorServices
{
    public class CalculatorService : ICalculatorService
    {
        private string previousValue;
        private string currentValue;
        private string displayValue;

        private string enqueuedOperation;

        public void RestoreState(string currentValue, string previousValue, string enqueuedOperation)
        {
            this.currentValue = currentValue;
            this.previousValue = previousValue;
            this.enqueuedOperation = enqueuedOperation;
        }

        public string PreviousValue { get { return this.previousValue; } }

        public string CurrentValue { get { return this.currentValue; } }

        public string EnqueuedOperation { get { return this.enqueuedOperation; } }

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
            if (string.IsNullOrEmpty(this.currentValue))
            {
                this.currentValue = string.Empty;
            }

            this.currentValue = currentValue + digit;
            return this.currentValue;
        }

        private string HandleOperation(string currentValue, string previousValue, char operation)
        {
            if (operation == 'c')
            {
                this.previousValue = string.Empty;
                this.currentValue = string.Empty;
                this.enqueuedOperation = string.Empty;
                return "0";
            }

            if (string.IsNullOrEmpty(currentValue) && operation == '-')
            {
                this.previousValue = "0";
                this.enqueuedOperation = operation.ToString();
                return "0";
            }

            if (string.IsNullOrEmpty(previousValue))
            {
                this.previousValue = this.currentValue;
                this.currentValue = string.Empty;
                this.enqueuedOperation = operation.ToString();
                return this.previousValue;
            }

            if (operation == 's' && !string.IsNullOrEmpty(this.currentValue))
            {
                var value = double.Parse(this.currentValue);
                var sqrt = Math.Sqrt(value);
                return sqrt.ToString();
            }

            if (string.IsNullOrEmpty(this.enqueuedOperation) && string.IsNullOrEmpty(this.previousValue))
            {
                this.enqueuedOperation = operation.ToString();
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
            switch (enqueuedOperation[0])
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
            this.enqueuedOperation = operation.ToString();

            return result.ToString();
        }
    }
}
