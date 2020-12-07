using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;

namespace RSPO_UP_6.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        private EntitySettingsViewModel _cowSettings;
        private EntitySettingsViewModel _wolfSettings;
        private EntitySettingsViewModel _bombSettings;
        private EntitySettingsViewModel _cannabisSettings;

        private string _cowDelayText = "5";
        private string _wolfDelayText = "100";
        private string _livesText = "3";
        private int _lives = 3;
        private int _cowDelay = 5;
        private int _wolfDelay = 100;

        public int CowLivesCount
        {
            get => _lives;
            set => SetValue(ref _lives, value);
        }

        public string CowDelay
        {
            get => _cowDelayText;
            set => SetValue(ref _cowDelayText, value);
        }

        public string WolfDelay
        {
            get => _wolfDelayText;
            set => SetValue(ref _wolfDelayText, value);
        }

        public string CowLives
        {
            get => _livesText;
            set => SetValue(ref _livesText, value);
        }

        public ICommand ChangeCowImageCommand { get; }
        public ICommand ChangeWolfImageCommand { get; }

        public ICommand ChangeCowDelayCommand { get; }
        public ICommand ChangeWolfDelayCommand { get; }

        public ICommand ChangeCowLivesCountCommand { get; }

        public EntitySettingsViewModel CowSettings
        {
            get => _cowSettings;
            set => SetValue(ref _cowSettings, value);
        }
        public EntitySettingsViewModel WolfSettings
        {
            get => _wolfSettings;
            set => SetValue(ref _wolfSettings, value);
        }
        public EntitySettingsViewModel BombSettings
        {
            get => _bombSettings;
            set => SetValue(ref _bombSettings, value);
        }
        public EntitySettingsViewModel CannabisSettings
        {
            get => _cannabisSettings;
            set => SetValue(ref _cannabisSettings, value);
        }

        private void OnChangeCowImageExecuted()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Images(*.jpg, *.gif;*.png)|*.jpg;*.gif;*.png"
            };
            if (dialog.ShowDialog() ?? false)
            {
                CowSettings.ImagePath = dialog.FileName;
            }
        }

        private void OnChangeWolfImageExecuted()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Images(*.jpg, *.gif;*.png)|*.jpg;*.gif;*.png"
            };
            if (dialog.ShowDialog() ?? false)
            {
                WolfSettings.ImagePath = dialog.FileName;
            }
        }

        private void OnChangeCowDelayExecuted()
        {
            CowSettings.Delay = _cowDelay;
        }

        private bool CanChangeCowDelayExecute() => int.TryParse(CowDelay, out _cowDelay) && _cowDelay >= 0;

        private void OnChangeWolfDelayExecuted()
        {
            WolfSettings.Delay = _wolfDelay;
        }

        private bool CanChangeCowLivesExecute() => int.TryParse(CowLives, out _lives) && _cowDelay >= 0 && _lives <= 5;

        private void OnChangeCowLivesExecuted()
        {
            if (_lives == 0 || _lives > 5)
            {
                CowLivesCount = 3;
            }
            else
            {
                CowLivesCount = _lives;
            }
        }

        private bool CanChangeWolfDelayExecute() => int.TryParse(WolfDelay, out _wolfDelay) && _wolfDelay >= 0;

        public SettingsViewModel()
        {
            ChangeCowImageCommand = new RelayCommand(OnChangeCowImageExecuted);
            ChangeWolfImageCommand = new RelayCommand(OnChangeWolfImageExecuted);

            ChangeCowDelayCommand = new RelayCommand(OnChangeCowDelayExecuted, CanChangeCowDelayExecute);
            ChangeWolfDelayCommand = new RelayCommand(OnChangeWolfDelayExecuted, CanChangeWolfDelayExecute);

            ChangeCowLivesCountCommand = new RelayCommand(OnChangeCowLivesExecuted, CanChangeCowLivesExecute);
        }
    }
}
