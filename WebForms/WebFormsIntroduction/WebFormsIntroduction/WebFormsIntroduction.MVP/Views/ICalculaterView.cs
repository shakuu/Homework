using System;
using WebFormsIntroduction.MVP.EventsArgs;
using WebFormsIntroduction.MVP.Models;

using WebFormsMvp;

namespace WebFormsIntroduction.MVP.Views
{
    public interface ICalculaterView : IView<CalculatorViewModel>
    {
        event EventHandler<CalculatorEventArgs> Sum;
    }
}
