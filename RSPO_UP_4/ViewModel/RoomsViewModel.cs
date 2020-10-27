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
        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }
        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }

        private PlayerControllerViewModel _player;
        private Timer _timer;
        private bool _nightTime;
        private string _timeString;

        public bool NightTime
        {
            get => _nightTime;
            set => SetValue(ref _nightTime, value);
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

        #region keyBindings

        #region moveRight

        private bool CanMoveRight => Player.Right > 0;

        private void OnMoveRight() => Player.Left += 3;

        #endregion

        #region moveLeft

        private bool CanMoveLeft => Player.Left > 0;

        private void OnMoveLeft() => Player.Left -= 3;

        #endregion

        #region moveUp

        private bool CanMoveUp => Player.Up > 0;

        private void OnMoveUp() => Player.Up -= 3;

        #endregion

        #region moveDown

        private bool CanMoveDown => Player.Down > 0;

        private void OnMoveDown() => Player.Up += 3;

        #endregion

        #endregion

        public RoomsViewModel()
        {
            Player = new PlayerControllerViewModel();
            MoveUpCommand = new RelayCommand(OnMoveUp, CanMoveUp);
            MoveDownCommand = new RelayCommand(OnMoveDown, CanMoveDown);
            MoveRightCommand = new RelayCommand(OnMoveRight, CanMoveRight);
            MoveLeftCommand = new RelayCommand(OnMoveLeft, CanMoveLeft);
            TimerCallback callback = UpdateTime;
            _timer = new Timer(callback, null, 0, 100);
        }

        private void UpdateTime(object state)
        {
            DateString = DateTime.Now.ToLongTimeString();
            NightTime = DateTime.Now.Hour > 23 && DateTime.Now.Hour < 4;
        }
    }
}
