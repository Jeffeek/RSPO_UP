using System;
using System.Windows.Threading;
using RoyT.TimePicker;
using RSPO_UP_4.ViewModel;

namespace RSPO_UP_4.Model.Controller
{
    public class TimeController : ViewModelBase
    {
        private bool _isStopped = true;
        private bool _isNightTime;
        private DispatcherTimer _timer;
        private AnalogueTime _time;

        public bool IsStopped
        {
            get => _isStopped;
            set => SetValue(ref _isStopped, value);
        }

        public bool IsNightTime
        {
            get => _isNightTime;
            set => SetValue(ref _isNightTime, value);
        }

        public AnalogueTime Time
        {
            get => _time;
            set
            {
                if (IsStopped)
                    SetValue(ref _time, value);
                else
                    SetValue(ref _time, _time);
                CheckForNightTime();
            }
        }

        public TimeController()
        {
            Time = new AnalogueTime(DateTime.Now.Hour % 12, DateTime.Now.Minute, Meridiem.AM);
            _timer = new DispatcherTimer(TimeSpan.FromMinutes(1.0),
                                                DispatcherPriority.Background,
                                                ((sender, args) => UpdateTime()), 
                                                Dispatcher.CurrentDispatcher);
            Start();
        }

        public void Start()
        {
            _timer?.Start();
            IsStopped = false;
        }

        public void Stop()
        {
            _timer?.Stop();
            IsStopped = true;
        }

        private void UpdateTime()
        {
            _isStopped = true;
            var time = new AnalogueTime(Time.Hour, Time.Minute + 1, Meridiem.AM);
            Time = time;
            _isStopped = false;
        }

        private void CheckForNightTime()
        {
            if (Time.Meridiem == Meridiem.AM)
                IsNightTime = Time.Hour > 11 || Time.Hour < 4;
            else
                IsNightTime = Time.Hour > 23 || Time.Hour < 4;
        }
    }
}
