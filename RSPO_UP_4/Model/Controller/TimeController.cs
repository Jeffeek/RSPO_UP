#region Using namespaces

using System;
using System.Windows.Threading;
using RoyT.TimePicker;
using RSPO_UP_4.ViewModel;

#endregion

namespace RSPO_UP_4.Model.Controller
{
	public class TimeController : ViewModelBase
	{
		private readonly DispatcherTimer _timer;
		private readonly Action _turnOnLamps;
		private readonly Action _turnOffLamps;
		private bool _isStopped = true;
		private bool _isNightTime;
		private AnalogueTime _time;

		public TimeController(Action turnOnLamps, Action turnOffLamps)
		{
			_turnOnLamps = turnOnLamps;
			_turnOffLamps = turnOffLamps;
			Time = new AnalogueTime(DateTime.Now.Hour % 12, DateTime.Now.Minute, Meridiem.AM);
			_timer = new DispatcherTimer(TimeSpan.FromMinutes(1.0),
			                             DispatcherPriority.Background,
			                             (sender, args) => UpdateTime(),
			                             Dispatcher.CurrentDispatcher);

			Start();
		}

		public bool IsStopped
		{
			get => _isStopped;
			set
			{
				SetValue(ref _isStopped, value);
				if (_isNightTime)
					_turnOnLamps?.Invoke();
				else
					_turnOffLamps?.Invoke();
			}
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
			IsNightTime = Time.Hour > 11 || Time.Hour < 4;
		}
	}
}