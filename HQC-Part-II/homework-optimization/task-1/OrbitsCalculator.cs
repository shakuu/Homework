using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace SolarSystem
{
    class OrbitsCalculator : INotifyPropertyChanged
    {
        private DateTime _startTime;
        private DispatcherTimer _timer;

        const double EarthYear = 365.25;
        const double EarthRotationPeriod = 1.0;
        const double SunRotationPeriod = 25.0;
        const double TwoPi = Math.PI * 2;

        private double _daysPerSecond = 2;

        private PropertyChangedEventArgs DaysPerSecondEventArgs = new PropertyChangedEventArgs("DaysPerSecond");
        private PropertyChangedEventArgs DaysEventArgs = new PropertyChangedEventArgs("Days");
        private PropertyChangedEventArgs EarthOrbitPositionXEventArgs = new PropertyChangedEventArgs("EarthOrbitPositionX");
        private PropertyChangedEventArgs EarthOrbitPositionYEventArgs = new PropertyChangedEventArgs("EarthOrbitPositionY");
        private PropertyChangedEventArgs EarthRotationAngleEventArgs = new PropertyChangedEventArgs("EarthRotationAngle");
        private PropertyChangedEventArgs SunRotationAngleEventArgs = new PropertyChangedEventArgs("SunRotationAngle");

        public OrbitsCalculator()
        {
            EarthOrbitPositionX = EarthOrbitRadius;
            DaysPerSecond = 2;
        }

        public double DaysPerSecond
        {
            get { return _daysPerSecond; }
            set { _daysPerSecond = value; Update(DaysPerSecondEventArgs); }
        }

        public double EarthOrbitRadius { get { return 40; } set { } }
        public double Days { get; set; }
        public double EarthRotationAngle { get; set; }
        public double SunRotationAngle { get; set; }
        public double EarthOrbitPositionX { get; set; }
        public double EarthOrbitPositionY { get; set; }
        public double EarthOrbitPositionZ { get; set; }
        public bool ReverseTime { get; set; }
        public bool Paused { get; set; }

        public void StartTimer()
        {
            _startTime = DateTime.Now;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += new EventHandler(OnTimerTick);
            _timer.Start();
        }

        private void StopTimer()
        {
            _timer.Stop();
            _timer.Tick -= OnTimerTick;
            _timer = null;
        }

        public void Pause(bool doPause)
        {
            if (doPause)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }

        void OnTimerTick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            Days += (now - _startTime).TotalMilliseconds * DaysPerSecond / 1000.0 * (ReverseTime ? -1 : 1);
            _startTime = now;
            Update(DaysPerSecondEventArgs);
            OnTimeChanged();
        }

        private void OnTimeChanged()
        {
            EarthPosition();
            EarthRotation();
            SunRotation();
        }

        private void EarthPosition()
        {
            double angle = 2 * Math.PI * Days / EarthYear;
            EarthOrbitPositionX = EarthOrbitRadius * Math.Cos(angle);
            EarthOrbitPositionY = EarthOrbitRadius * Math.Sin(angle);
            Update(EarthOrbitPositionXEventArgs);
            Update(EarthOrbitPositionYEventArgs);
        }

        private void EarthRotation()
        {
            EarthRotationAngle = ((double)360) * Days / EarthRotationPeriod;
            Update(EarthRotationAngleEventArgs);
        }

        private void SunRotation()
        {
            SunRotationAngle = 360 * Days / SunRotationPeriod;
            Update(SunRotationAngleEventArgs);
        }

        private void Update(PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, args);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
