using System;

using WebFormsMvp;

namespace WebFormsControls.Calculator
{
    public interface ICalculatorView : IView<CalculatorViewModel>
    {
        event EventHandler<CalculatorEventArgs> UserInput;
    }
}
