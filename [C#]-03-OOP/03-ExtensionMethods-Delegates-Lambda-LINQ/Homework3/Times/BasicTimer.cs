
namespace Homework3.Times
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Threading;

    public static class BasicTimer
    {
        delegate void ToExecute(); 

        public static void OnTimer(Action invoke, int seconds)
        {
            var sleep = seconds * 1000;

            for (int i = 0; i < 10; i++)
            {
                invoke.Invoke();

                Thread.Sleep(sleep);
            }
        }
    }
}
