using System;

using WebFormsMvp;

using WebFormsIntroduction.MVP.EventsArgs;
using WebFormsIntroduction.MVP.Models;

namespace WebFormsIntroduction.MVP.Views
{
    public interface ICalculatorView : IView<CalculatorViewModel>
    {
        event EventHandler<CalculatorEventArgs> Sum;
    }
}
