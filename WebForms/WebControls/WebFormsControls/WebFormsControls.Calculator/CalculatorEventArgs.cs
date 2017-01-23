using System;

namespace WebFormsControls.Calculator
{
    public class CalculatorEventArgs : EventArgs
    {
        public CalculatorEventArgs(string input)
        {
            this.Input = input;
        }

        public string Input { get; set; }
    }
}
