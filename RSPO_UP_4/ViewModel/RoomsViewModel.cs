using System;
using System.Threading;
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
        public ICommand TouchLampCommand { get; }
        public ICommand GuestsCommand { get; }

        private PlayerController _playerController;
        private Timer _timerRealTime;
        private bool _nightTime;
        private string _timeString;

        public RoomViewModel FirstRoom { get; }
        public RoomViewModel SecondRoom { get; }
        public RoomViewModel ThirdRoom { get; }
        public BathroomViewModel Bathroom { get; }

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

        public PlayerController PlayerController
        {
            get => _playerController;
            set => SetValue(ref _playerController, value);
        }

        #region keyBindings

        #region moveRight

        private bool CanMoveRight => PlayerController.Right > 0;

        private void OnMoveRight()
        {
            PlayerController.GoRight();
            CheckPositionNearLamps();
        }

        #endregion

        #region moveLeft

        private bool CanMoveLeft => PlayerController.Left > 0;

        private void OnMoveLeft()
        {
            PlayerController.GoLeft();
            CheckPositionNearLamps();
        }

        #endregion

        #region moveUp

        private bool CanMoveUp => PlayerController.Up > 0;

        private void OnMoveUp()
        {
            PlayerController.GoUp();
            CheckPositionNearLamps();
        }

        #endregion

        #region moveDown

        private bool CanMoveDown => PlayerController.Down > 0;

        private void OnMoveDown()
        {
            PlayerController.GoDown();
            CheckPositionNearLamps();
        }

        #endregion


        private void OnTouchLamp()
        {
            if (FirstRoom.Lamp.IsPlayerNearLamp)
                FirstRoom.Lamp.IsOn = !FirstRoom.Lamp.IsOn;
            if (FirstRoom.Bruh.IsPlayerNearLamp)
                FirstRoom.Bruh.IsOn = !FirstRoom.Bruh.IsOn;

            if (SecondRoom.Lamp.IsPlayerNearLamp)
                SecondRoom.Lamp.IsOn = !SecondRoom.Lamp.IsOn;
            if (SecondRoom.Bruh.IsPlayerNearLamp)
                SecondRoom.Bruh.IsOn = !SecondRoom.Bruh.IsOn;

            if (ThirdRoom.Lamp.IsPlayerNearLamp)
                ThirdRoom.Lamp.IsOn = !ThirdRoom.Lamp.IsOn;
            if (ThirdRoom.Bruh.IsPlayerNearLamp)
                ThirdRoom.Bruh.IsOn = !ThirdRoom.Bruh.IsOn;

            if (Bathroom.Lamp.IsPlayerNearLamp)
                Bathroom.Lamp.IsOn = !Bathroom.Lamp.IsOn;
        }

        #endregion

        private void OnGuestsComing()
        {
            TurnOnAllLamps();
        }

        private void TurnOnAllLamps()
        {
            FirstRoom.Lamp.IsOn = true;
            FirstRoom.Bruh.IsOn = true;
            SecondRoom.Lamp.IsOn = true;
            SecondRoom.Bruh.IsOn = true;
            ThirdRoom.Lamp.IsOn = true;
            ThirdRoom.Bruh.IsOn = true;
        }

        private void CheckPositionNearLamps()
        {
            FirstRoom.Lamp.CheckPlayer(PlayerController);
            FirstRoom.Bruh.CheckPlayer(PlayerController);
            SecondRoom.Lamp.CheckPlayer(PlayerController);
            SecondRoom.Bruh.CheckPlayer(PlayerController);
            ThirdRoom.Lamp.CheckPlayer(PlayerController);
            ThirdRoom.Bruh.CheckPlayer(PlayerController);
            Bathroom.Lamp.CheckPlayer(PlayerController);
        }

        public RoomsViewModel()
        {
            PlayerController= new PlayerController();

            MoveUpCommand = new RelayCommand(OnMoveUp, CanMoveUp);
            MoveDownCommand = new RelayCommand(OnMoveDown, CanMoveDown);
            MoveRightCommand = new RelayCommand(OnMoveRight, CanMoveRight);
            MoveLeftCommand = new RelayCommand(OnMoveLeft, CanMoveLeft);

            GuestsCommand = new RelayCommand(OnGuestsComing, () => true);
            TouchLampCommand = new RelayCommand(OnTouchLamp, () => true);

            FirstRoom = new RoomViewModel(195, 300);
            SecondRoom = new RoomViewModel(195, 600);
            ThirdRoom = new RoomViewModel(425, 300);
            Bathroom = new BathroomViewModel(425,600);

            TimerCallback callback = UpdateTime;
            _timerRealTime = new Timer(callback, null, 0, 100);
        }

        private void UpdateTime(object state)
        {
            DateString = DateTime.Now.ToLongTimeString();
            NightTime = DateTime.Now.Hour > 23 && DateTime.Now.Hour < 4;
        }
    }
}
