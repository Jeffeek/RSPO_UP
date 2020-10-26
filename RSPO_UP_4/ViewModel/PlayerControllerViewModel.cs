using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_4.Model;

namespace RSPO_UP_4.ViewModel
{
    public class PlayerControllerViewModel : ViewModelBase
    {
        private PlayerController _playerController;

        public PlayerControllerViewModel()
        {
            PlayerController = new PlayerController();
        }
        public PlayerController PlayerController
        {
            get => _playerController;
            set => SetValue(ref _playerController, value);
        }

        public int Left
        {
            get => _playerController.Left;
            set
            {
                _playerController.Left = value;
                OnPropertyChanged(nameof(Left));
            }
        }

        public int Top
        {
            get => _playerController.Top;
            set
            {
                _playerController.Top = value;
                OnPropertyChanged(nameof(Top));
            }
        }
    }
}
