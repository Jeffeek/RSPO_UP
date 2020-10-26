using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_4.Model;

namespace RSPO_UP_4.ViewModel
{
    public class RoomsViewModel : ViewModelBase
    {
        public ICommand KeyPressCommand { get; }
        private PlayerControllerViewModel _player;
        private DateTime _time;
        private Timer _timer;
        private string _timeString;

        public bool NightTime => Time.Hour > 23 && Time.Hour < 4;

        public DateTime Time
        {
            get => _time;
            set
            {
                SetValue(ref _time, value);
                DateString = _time.ToLongTimeString();
            }
        }

        public string DateString 
        { 
            get => _timeString;
            set => SetValue(ref _timeString, value);
        }

        public PlayerControllerViewModel Player
        {
            get => _player;
            set => SetValue(ref _player, value);
        }

        private bool CanKeyPress => true;

        private void OnKeyPress()
        {

        }

        public RoomsViewModel()
        {
            KeyPressCommand = new RelayCommand(OnKeyPress, CanKeyPress);
            Player = new PlayerControllerViewModel();
            TimerCallback callback = UpdateTime;
            _timer = new Timer(callback, null, 0, 100);
        }

        private void UpdateTime(object obj)
        {
            Time = DateTime.Now;
        }
    }
}
