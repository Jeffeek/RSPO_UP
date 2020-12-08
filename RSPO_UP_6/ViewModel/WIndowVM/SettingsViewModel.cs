using System;
using System.IO;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using RSPO_UP_6.ViewModel.Entities;

namespace RSPO_UP_6.ViewModel.WIndowVM
{
    public enum GameRedirection : byte
    {
        CanChoose,
        AutoRedirect
    }

    public class SettingsViewModel : ViewModelBase
    {
        private EntitySettingsViewModel _cowSettings;
        private EntitySettingsViewModel _wolfSettings;
        private EntitySettingsViewModel _bombSettings;

        #region Images for heroes

        private string _cowImageSource = $"{Directory.GetCurrentDirectory()}\\Files\\cow.gif";
        private string _wolfImageSource = $"{Directory.GetCurrentDirectory()}\\Files\\wolf.png";

        public string CowImageSource
        {
            get => _cowImageSource;
            set => SetValue(ref _cowImageSource, value);
        }

        public string WolfImageSource
        {
            get => _wolfImageSource;
            set => SetValue(ref _wolfImageSource, value);
        }

        private void OnChangeCowImageExecuted()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Images(*.jpg, *.gif;*.png)|*.jpg;*.gif;*.png"
            };
            if (!(dialog.ShowDialog() ?? false)) return;
            CowImageSource = dialog.FileName;
        }

        private void OnChangeWolfImageExecuted()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Images(*.jpg, *.gif;*.png)|*.jpg;*.gif;*.png"
            };
            if (!(dialog.ShowDialog() ?? false)) return;
            WolfImageSource = dialog.FileName;
        }

        #endregion

        #region Cow lives

        private string _livesText = "3";
        private int _lives = 3;

        public int CowLives
        {
            get => _lives;
            set => SetValue(ref _lives, value);
        }

        public string CowLivesText
        {
            get => _livesText;
            set => SetValue(ref _livesText, value);
        }

        #endregion

        #region Cow Delay

        private string _cowDelayText = "0";
        private int _cowDelay = 0;

        public string CowDelayText
        {
            get => _cowDelayText;
            set => SetValue(ref _cowDelayText, value);
        }

        public int CowDelay
        {
            get => _cowDelay;
            set => SetValue(ref _cowDelay, value);
        }

        #endregion

        #region Wolf Delay

        private string _wolfDelayText = "100";
        private int _wolfDelay = 100;

        public string WolfDelayText
        {
            get => _wolfDelayText;
            set => SetValue(ref _wolfDelayText, value);
        }

        public int WolfDelay
        {
            get => _wolfDelay;
            set => SetValue(ref _wolfDelay, value);
        }

        #endregion

        #region Bomb delay

        private string _bombDelayText = "3000";
        private int _bombDelay = 3000;

        public string BombDelayText
        {
            get => _bombDelayText;
            set => SetValue(ref _bombDelayText, value);
        }

        public int BombDelay
        {
            get => _bombDelay;
            set => SetValue(ref _bombDelay, value);
        }

        #endregion

        #region Time for walkthrough

        #region 6x6

        private string _time6x6Text = "10";
        private int _time6x6 = 10;

        public string Time6x6Text
        {
            get => _time6x6Text;
            set => SetValue(ref _time6x6Text, value);
        }

        public int Time6X6
        {
            get => _time6x6;
            private set => SetValue(ref _time6x6, value);
        }

        #endregion

        #region 8x8

        private string _time8x8Text = "20";
        private int _time8x8 = 20;

        public int Time8X8
        {
            get => _time8x8;
            private set => SetValue(ref _time8x8, value);
        }

        public string Time8x8Text
        {
            get => _time8x8Text;
            set => SetValue(ref _time6x6Text, value);
        }

        #endregion

        #region 10x10

        private string _time10x10Text = "30";
        private int _time10x10 = 30;

        public int Time10X10
        {
            get => _time10x10;
            private set => SetValue(ref _time10x10, value);
        }

        public string Time10x10Text
        {
            get => _time10x10Text;
            set => SetValue(ref _time10x10Text, value);
        }

        #endregion

        #endregion

        #region Game type

        private GameRedirection _gameRedirectionType;
        private int _gameRedirectionIndex = 0;

        public GameRedirection GameRedirectionType
        {
            get => _gameRedirectionType;
            private set => SetValue(ref _gameRedirectionType, value);
        }

        public int GameRedirectionIndex
        {
            get => _gameRedirectionIndex;
            set
            {
                SetValue(ref _gameRedirectionIndex, value);
                GameRedirectionType =
                    GameRedirectionIndex == 0 ? GameRedirection.CanChoose : GameRedirection.AutoRedirect;
            }
        }
        

        #endregion

        #region Commands

        public ICommand ChangeCowImageCommand { get; }
        public ICommand ChangeWolfImageCommand { get; }
        public ICommand ApplyAllSettingsCommand { get; }

        #endregion

        #region Properties

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

        #endregion

        private bool CanApplyAllSettingsExecute()
        {
            var canApply = false;
            if (int.TryParse(CowLivesText, out var tempData))
            {
                canApply = tempData > 0 && tempData <= 7;
                if (!canApply)
                    return false;
            }
            else
                return false;
            tempData = -1;
            canApply = false;
            if (int.TryParse(CowDelayText, out tempData))
            {
                canApply = tempData >= 0 && tempData <= 2000;
                if (!canApply)
                    return false;
            }
            else
                return false;
            tempData = -1;
            canApply = false;
            if (int.TryParse(WolfDelayText, out tempData))
            {
                canApply = tempData >= 0 && tempData <= 2000;
                if (!canApply)
                    return false;
            }
            else
                return false;
            tempData = -1;
            canApply = false;
            if (int.TryParse(BombDelayText, out tempData))
            {
                canApply = tempData >= 1000 && tempData <= 5000;
                if (!canApply)
                    return false;
            }
            else
                return false;
            tempData = -1;
            canApply = false;
            if (int.TryParse(Time6x6Text, out tempData))
            {
                canApply = tempData >= 10 && tempData <= 30;
                if (!canApply)
                    return false;
            }
            else
                return false;
            tempData = -1;
            canApply = false;
            if (int.TryParse(Time8x8Text, out tempData))
            {
                canApply = tempData >= 20 && tempData <= 40;
                if (!canApply)
                    return false;
            }
            else
                return false;
            tempData = -1;
            canApply = false;
            if (int.TryParse(Time10x10Text, out tempData))
            {
                canApply = tempData >= 30 && tempData <= 50;
                if (!canApply)
                    return false;
            }
            else
                return false;

            return true;
        }

        private void OnApplyAllSettingsExecuted()
        {
            CowLives = int.Parse(CowLivesText);
            CowDelay = int.Parse(CowDelayText);
            WolfDelay = int.Parse(WolfDelayText);
            BombDelay = int.Parse(BombDelayText);
            Time6X6 = int.Parse(Time6x6Text);
            Time8X8 = int.Parse(Time8x8Text);
            Time10X10 = int.Parse(Time10x10Text);

            CowSettings = new EntitySettingsViewModel()
            {
                Delay = CowDelay,
                ImagePath = CowImageSource
            };
            WolfSettings = new EntitySettingsViewModel()
            {
                Delay = WolfDelay,
                ImagePath = WolfImageSource
            };
            BombSettings = new EntitySettingsViewModel()
            {
                Delay = BombDelay
            };
        }

        public SettingsViewModel()
        {
            ChangeCowImageCommand = new RelayCommand(OnChangeCowImageExecuted);
            ChangeWolfImageCommand = new RelayCommand(OnChangeWolfImageExecuted);
            ApplyAllSettingsCommand = new RelayCommand(OnApplyAllSettingsExecuted, CanApplyAllSettingsExecute);
        }
    }
}
