// https://msdn.microsoft.com/en-us/library/w369ty8x.aspx
// Description
namespace Homework3.TimedEvent
{
    using System;
    using System.Threading;

    public class Timer
    {
        public event EventHandler TimedEvent;

        private int timer;

        public Timer(int seconds)
        {
            this.Time = seconds * 1000;
        }

        public int Time
        {
            get
            {
                return this.timer;
            }
            set
            {
                this.timer = value;
            }
        }
        
        #region Methods
        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                OnTimedEvent();

                Thread.Sleep(this.Time);
            }
        }

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnTimedEvent()
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler handler = TimedEvent;

            // Event will be null if there are no subscribers
            if (handler != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                //e.Message += String.Format(" at {0}", DateTime.Now.ToString());

                // Use the () operator to raise the event.
                handler(this, null);
            }
        }
        #endregion
    }
}
