using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;

namespace RSPO_UP_6.ViewModel
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
        private EntitySettingsViewModel _cannabisSettings;

        private string _cowDelayText = "5";
        private string _wolfDelayText = "100";
        private string _bombDelayText = "1000";

        private int _cowDelay = 5;
        private int _wolfDelay = 100;
        private int _bombDelay = 1000;

        private string _livesText = "3";
        private int _lives = 3;

        private string _time6x6Text = "10";
        private string _time8x8Text = "20";
        private string _time10x10Text = "30";
        private int _time6x6 = 10;
        private int _time8x8 = 20;
        private int _time10x10 = 30;

        public int GameRedirectionIndex
        {
            set => GameRedirection = value == 0 ? 
                GameRedirection.CanChoose : GameRedirection.AutoRedirect;
        }

        public GameRedirection GameRedirection { get; private set; }

        public int Time6X6
        {
            get => _time6x6;
            private set => SetValue(ref _time6x6, value);
        }

        public int Time8X8
        {
            get => _time8x8; 
            private set => SetValue(ref _time8x8, value);
        }

        public int Time10X10
        {
            get => _time10x10; 
            private set => SetValue(ref _time10x10, value);
        }

        public string Time6x6
        {
            get => _time6x6Text;
            set => SetValue(ref _time6x6Text, value);
        }

        public string Time8x8
        {
            get => _time8x8Text;
            set => SetValue(ref _time6x6Text, value);
        }

        public string Time10x10
        {
            get => _time10x10Text;
            set => SetValue(ref _time10x10Text, value);
        }

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

        public string BombDelay
        {
            get => _bombDelayText;
            set => SetValue(ref _bombDelayText, value);
        }

        public ICommand ChangeCowImageCommand { get; }
        public ICommand ChangeWolfImageCommand { get; }

        public ICommand ChangeCowDelayCommand { get; }
        public ICommand ChangeWolfDelayCommand { get; }
        public ICommand ChangeBombDelayCommand { get; }

        public ICommand ChangeCowLivesCountCommand { get; }
        public ICommand ChangeWalkTimeCommand { get; }

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

        private bool CanChangeCowDelayExecute() => int.TryParse(CowDelay, out _cowDelay) && 
                                                   _cowDelay >= 0 &&
                                                   _cowDelay <= 1000;

        private void OnChangeWolfDelayExecuted()
        {
            WolfSettings.Delay = _wolfDelay;
        }

        private bool CanChangeWolfDelayExecute() => int.TryParse(WolfDelay, out _wolfDelay) &&
                                                    _wolfDelay >= 0 &&
                                                    _wolfDelay <= 1000;


        private void OnChangeBombDelayExecuted()
        {
            BombSettings.Delay = _bombDelay;
        }

        private bool CanChangeBombDelayExecute() => int.TryParse(BombDelay, out _bombDelay) &&
                                                    _bombDelay >= 1000 &&
                                                    _lives <= 5000;

        private void OnChangeCowLivesExecuted()
        {
            if (_lives == 0 || _lives > 7)
            {
                CowLivesCount = 7;
            }
            else
            {
                CowLivesCount = _lives;
            }
        }

        private bool CanChangeCowLivesExecute() => int.TryParse(CowLives, out _lives) && _cowDelay >= 0 && _lives <= 5;


        private void OnApplyWalkTimeExecuted()
        {
            Time10X10 = _time10x10;
            Time8X8 = _time8x8;
            Time6X6 = _time6x6;
        }

        private bool CanApplyWalkTimeExecute()
        {
            return int.TryParse(_time6x6Text, out _time6x6) &&
                   int.TryParse(_time8x8Text, out _time8x8) &&
                   int.TryParse(_time10x10Text, out _time10x10) &&
                   Time6X6 >= 10 && Time6X6 <= 50 &&
                   Time8X8 >= 20 && Time8X8 <= 60 &&
                   Time10X10 >= 30 && Time10X10 <= 70;
        }

        public SettingsViewModel()
        {
            ChangeCowImageCommand = new RelayCommand(OnChangeCowImageExecuted);
            ChangeWolfImageCommand = new RelayCommand(OnChangeWolfImageExecuted);

            ChangeCowDelayCommand = new RelayCommand(OnChangeCowDelayExecuted, CanChangeCowDelayExecute);
            ChangeWolfDelayCommand = new RelayCommand(OnChangeWolfDelayExecuted, CanChangeWolfDelayExecute);
            ChangeBombDelayCommand = new RelayCommand(OnChangeBombDelayExecuted, CanChangeBombDelayExecute);

            ChangeCowLivesCountCommand = new RelayCommand(OnChangeCowLivesExecuted, CanChangeCowLivesExecute);

            ChangeWalkTimeCommand = new RelayCommand(OnApplyWalkTimeExecuted, CanApplyWalkTimeExecute);
        }
    }
}
