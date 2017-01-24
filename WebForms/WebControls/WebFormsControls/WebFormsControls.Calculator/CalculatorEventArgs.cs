using System;

namespace WebFormsControls.Calculator
{
    public class CalculatorEventArgs : EventArgs
    {
        public CalculatorEventArgs(string input, string prev, string current, string operation)
        {
            this.Input = input;
            this.PreviousValue = prev;
            this.CurrentValue = current;
            this.EnqueuedOperation = operation;
        }

        public string Input { get; set; }

        public string PreviousValue { get; set; }

        public string CurrentValue { get; set; }

        public string EnqueuedOperation { get; set; }
    }
}
