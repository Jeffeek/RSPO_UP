using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_6.Model.Map;
using RSPO_UP_6.View;
using RSPO_UP_6.View.Maps;

namespace RSPO_UP_6.ViewModel
{
    public class CowAndWeedGameViewModel : ViewModelBase
    {
        private SettingsViewModel _settings;
        private CowViewModel _cow;
        private WolfViewModel _wolf;
        private BombViewModel _bomb;
        private CannabisViewModel _cannabis;
        private Page _currentPage;
        private IMap _currentMap;

        public ICommand OpenSettingsCommand { get; }

        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }
        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                SetValue(ref _currentPage, value);
                _currentPage.DataContext = this;
            }
        }

        public CowViewModel Cow
        {
            get => _cow;
            set => SetValue(ref _cow, value);
        }

        public WolfViewModel Wolf
        {
            get => _wolf;
            set => SetValue(ref _wolf, value);
        }

        public BombViewModel Bomb
        {
            get => _bomb;
            set => SetValue(ref _bomb, value);
        }

        public CannabisViewModel Cannabis
        {
            get => _cannabis;
            set => SetValue(ref _cannabis, value);
        }

        public SettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        private void OnOpenSettingsExecuted()
        {
            if (CurrentPage is SettingsPage)
            {
                CurrentPage = new Map10x10()
                {
                    DataContext = this
                };
                
                Cow.Lives = new ObservableCollection<bool>(new bool[Settings.CowLivesCount]);
            }
            else
            {
                CurrentPage = new SettingsPage()
                {
                    DataContext = this
                };
            }
        }

        private void ReloadGame()
        {
            Cow.Row = 0;
            Wolf.Row = _currentMap.Size - 1;
        }

        public CowAndWeedGameViewModel()
        {
            Cow = new CowViewModel() {Size = 10};
            Wolf = new WolfViewModel() {Size = 10};
            Bomb = new BombViewModel() {Size = 10};
            Cannabis = new CannabisViewModel() {Size = 10};
            Cow.CowPositionChanged += Wolf.CowMovedExecuted;
            Settings = new SettingsViewModel()
            {
                BombSettings = Bomb.Settings,
                CannabisSettings = Cannabis.Settings,
                WolfSettings = Wolf.Settings,
                CowSettings = Cow.Settings
            };

            MoveDownCommand = new RelayCommand(async () => await _cow.MoveDown());
            MoveUpCommand = new RelayCommand( async () => await _cow.MoveUp());
            MoveRightCommand = new RelayCommand( async () => await _cow.MoveRight());
            MoveLeftCommand = new RelayCommand( async () => await _cow.MoveLeft());
            OpenSettingsCommand = new RelayCommand(OnOpenSettingsExecuted);
            CurrentPage = new Map10x10()
            {
                DataContext = this
            };
        }
    }
}
