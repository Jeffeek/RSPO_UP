using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_4.Model;

namespace RSPO_UP_4.ViewModel
{
    public class LampViewModel : ViewModelBase
    {
        public ICommand TurnOnLampCommand { get; }

        private Lamp _lamp;
        private bool _isPlayerNearLamp;
        private bool _isOn;

        private int _top;
        private int _left;

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

        public void CheckPlayer(int playerUp, int playerLeft)
        {
            IsPlayerNearLamp =  Math.Abs(_top - playerUp) < 20 && Math.Abs(_left - playerLeft) < 20;
        }
    }
}
