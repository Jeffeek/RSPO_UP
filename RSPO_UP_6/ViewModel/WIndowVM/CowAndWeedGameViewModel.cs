using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using RSPO_UP_6.Model;
using RSPO_UP_6.Model.Map;
using RSPO_UP_6.View;
using RSPO_UP_6.View.Maps;
using RSPO_UP_6.ViewModel.Entities;

namespace RSPO_UP_6.ViewModel.WindowVM
{
    public class CowAndWeedGameViewModel : ViewModelBase
    {
        private DateTime _currentGameTime = new DateTime(2020, 12, 1, 0, 0, 0);
        private int _currentMaxGameTime;

        #region Pages

        private Page _previousPage;
        private Page _currentPage;

        #endregion

        #region ViewModels

        private SettingsViewModel _settings;
        private MapViewModel _currentMap;

        #endregion

        #region Commands

        public ICommand OpenSettingsCommand { get; }
        public ICommand OpenMapCommand { get; }

        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }
        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }

        #endregion

        #region Properties

        public DateTime CurrentGameTime
        {
            get => _currentGameTime;
            private set => SetValue(ref _currentGameTime, value);
        }

        public MapViewModel CurrentMap
        {
            get => _currentMap;
            set => SetValue(ref _currentMap, value);
        }

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                SetValue(ref _currentPage, value);
                if (_currentPage != null)
                    _currentPage.DataContext = this;
            }
        }

        public SettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        #endregion

        private void OnOpenSettingsExecuted()
        {
            if (CurrentPage is SettingsPage)
            {
                CurrentPage = _previousPage;
                if (CurrentMap != null)
                    StartGame();
            }
            else
            {
                if (CurrentMap != null)
                    StopGame();
                _previousPage = CurrentPage;
                CurrentPage = new SettingsPage();
            }
        }

        private void OnLoadMapExecute()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt"
            };
            if (!(dialog.ShowDialog() ?? false)) return;
            var file = new FileWorker(dialog.FileName);
            var text = file.Read();
            var map = TextToMapConverter.Convert(text);
            StopGame();
            CurrentMap = new MapViewModel(map);
            CurrentMap.OnGameResult += OnGameResult;
            SetCurrentMapPage();
            CurrentMap.StartMap();
            StartGame();
        }

        private void SetCurrentMapPage()
        {
            switch (CurrentMap.Map.Size)
            {
                case 10:
                    CurrentPage = new Map10x10(CurrentMap.Bricks);
                    _currentMaxGameTime = Settings.Time10X10;
                    break;
                case 8:
                    CurrentPage = new Map8x8(CurrentMap.Bricks);
                    _currentMaxGameTime = Settings.Time8X8;
                    break;
                case 6:
                    _currentMaxGameTime = Settings.Time6X6;
                    CurrentPage = new Map6x6(CurrentMap.Bricks);
                    break;
                default:
                    throw new Exception();
            }
        }

        #region Game time

        private async Task StopGame()
        {
            if (CurrentMap == null) return;
            CurrentMap.IsGameStopped = true;
            CurrentGameTime = new DateTime(2020, 12, 1, 1, 0, 0);
            await Task.Delay(2000);
        }

        private void StartGame()
        {
            if (CurrentMap == null) throw new Exception();
            if (Settings.CowSettings == null) throw new Exception();
            CurrentMap.Cow.Settings = Settings.CowSettings;
            for (int i = 0; i < Settings.CowLives; i++)
            {
                var live = new LiveViewModel();
                CurrentMap.Cow.Lives.Add(live);
            }
            CurrentMap.Bomb.Settings = Settings.BombSettings;
            CurrentMap.Wolf.Settings = Settings.WolfSettings;
            CurrentMap.IsGameStopped = false;
            CurrentMap.Bomb.Start(); 
            CurrentMap.Cannabis.Start();
            IncrementGameTime();
        }

        #endregion

        private async Task IncrementGameTime()
        {
            while (CurrentGameTime.Minute * 60 + CurrentGameTime.Second < _currentMaxGameTime && !CurrentMap.IsGameStopped)
            {
                CurrentGameTime = CurrentGameTime.AddSeconds(1);
                await Task.Delay(1000);
            }
            CurrentGameTime = new DateTime(2020, 12, 1, 1, 0, 0);
            if (!CurrentMap.IsGameStopped)
                OnGameResult(this, false);
        }

        #region Event Handlers

        private void OnGameResult(object sender, bool isWin)
        {
            StopGame();
            MessageBox.Show(isWin ? "CONGRAT" : "FUC");
            if (!isWin) return;
            if (Settings.GameRedirectionType == GameRedirection.AutoRedirect)
            {
                CurrentMap = new MapViewModel(CurrentMap.Map);
                CurrentMap.OnGameResult += OnGameResult;
                SetCurrentMapPage();
                CurrentMap.StartMap();
                StartGame();
            }
            else
            {
                MessageBox.Show("Choose the next map");
                OnLoadMapExecute();
            }
        }

        #endregion

        public CowAndWeedGameViewModel()
        {
            MoveDownCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveDown(), () => CurrentMap != null && CurrentMap.IsGameStopped == false);
            MoveUpCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveUp(), () => CurrentMap != null && CurrentMap.IsGameStopped == false);
            MoveRightCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveRight(), () => CurrentMap != null && CurrentMap.IsGameStopped == false);
            MoveLeftCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveLeft(), () => CurrentMap != null && CurrentMap.IsGameStopped == false);
            OpenSettingsCommand = new RelayCommand(OnOpenSettingsExecuted);
            OpenMapCommand = new RelayCommand(OnLoadMapExecute);
            Settings = new SettingsViewModel();
        }
    }
}
