using System;

namespace WebFormsControls.RandomNumber
{
    public class RandomEventArgs : EventArgs
    {
        public RandomEventArgs(string min, string max)
        {
            this.MinimumValue = min;
            this.MaximumValue = max;
        }

        public string MinimumValue { get; set; }

        public string MaximumValue { get; set; }
    }
}
