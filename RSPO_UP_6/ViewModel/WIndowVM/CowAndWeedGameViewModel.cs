using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using RSPO_UP_6.Model;
using RSPO_UP_6.Model.Map;
using RSPO_UP_6.View;
using RSPO_UP_6.View.Maps;
using RSPO_UP_6.ViewModel.WIndowVM;

namespace RSPO_UP_6.ViewModel
{
    public class CowAndWeedGameViewModel : ViewModelBase
    {
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
                    CurrentMap.Bomb.IsGameStopped = false;
            }
            else
            {
                if (CurrentMap != null)
                    CurrentMap.Bomb.IsGameStopped = true;
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
            CurrentMap = new MapViewModel(map);
            
            SetCurrentMapPage();
            StartGame();
        }

        private void SetCurrentMapPage()
        {
            switch (CurrentMap.Map.Size)
            {
                case 10:
                    CurrentPage = new Map10x10(CurrentMap.Bricks);
                    break;
                case 8:
                    CurrentPage = new Map8x8(CurrentMap.Bricks);
                    break;
                case 6:
                    CurrentPage = new Map6x6(CurrentMap.Bricks);
                    break;
                default:
                    throw new Exception();
            }
        }

        private void StopGame()
        {

        }

        private void StartGame()
        {

        }

        private void OnGameResult(object sender, bool isWin)
        {
            StopGame();
            MessageBox.Show(isWin ? "CONGRAT" : "FUC");
        }

        public CowAndWeedGameViewModel()
        {
            MoveDownCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveDown());
            MoveUpCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveUp());
            MoveRightCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveRight());
            MoveLeftCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveLeft());
            OpenSettingsCommand = new RelayCommand(OnOpenSettingsExecuted);
            OpenMapCommand = new RelayCommand(OnLoadMapExecute);
            Settings = new SettingsViewModel();
        }
    }
}
