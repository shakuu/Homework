using System;

namespace WebFormsIntroduction.MVP.EventsArgs
{
    public class CalculatorEventArgs : EventArgs
    {
        public CalculatorEventArgs(string valueA, string valueB)
        {
            this.ValueA = valueA;
            this.ValueB = valueB;
        }

        public string ValueA { get; set; }

        public string ValueB { get; set; }
    }
}
