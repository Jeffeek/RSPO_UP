using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_4.Model;
using RSPO_UP_4.Model.Controller;

namespace RSPO_UP_4.ViewModel
{
    public class LampViewModel : ViewModelBase
    {
        public ICommand TurnOnLampCommand { get; }

        private Lamp _lamp;
        private bool _isPlayerNearLamp;
        private bool _isOn;

        private readonly int _top;
        private readonly int _left;

        public LampViewModel(int top, int left)
        {
            _lamp = new Lamp();
            _top = top;
            _left = left;
            TurnOnLampCommand = new RelayCommand(ChangeState, IsPlayerNearLamp);
        }

        public bool IsOn
        {
            get => _isOn;
            set => SetValue(ref _isOn, value);
        }

        private void ChangeState()
        {
            IsOn = !IsOn;
        }

        public bool IsPlayerNearLamp
        {
            get => _isPlayerNearLamp;
            set => SetValue(ref _isPlayerNearLamp, value);
        }

        public void CheckPlayer(in PlayerController controller)
        {
            int radius = 30;
            IsPlayerNearLamp = Math.Abs(_top - controller.Up) < radius && 
                               Math.Abs(_left - controller.Left) <= radius;
        }
    }
}
