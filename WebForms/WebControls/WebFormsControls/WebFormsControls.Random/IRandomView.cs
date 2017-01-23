using System;

using WebFormsMvp;

namespace WebFormsControls.RandomNumber
{
    public interface IRandomView : IView<RandomViewModel>
    {
        event EventHandler<RandomEventArgs> Generate;
    }
}
