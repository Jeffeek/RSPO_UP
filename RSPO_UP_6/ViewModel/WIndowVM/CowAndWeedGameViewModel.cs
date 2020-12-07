using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using RSPO_UP_6.Model;
using RSPO_UP_6.Model.Map;
using RSPO_UP_6.View;
using RSPO_UP_6.View.Maps;

namespace RSPO_UP_6.ViewModel
{
    public class CowAndWeedGameViewModel : ViewModelBase
    {
        private SettingsViewModel _settings;
        private Page _currentPage;

        private MapViewModel _map;

        public ICommand OpenSettingsCommand { get; }
        public ICommand OpenMapCommand { get; }

        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }
        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }

        public MapViewModel CurrentMap
        {
            get => _map;
            set => SetValue(ref _map, value);
        }

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                SetValue(ref _currentPage, value);
                _currentPage.DataContext = this;
            }
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
                CurrentPage = new Map10x10(CurrentMap.Bricks, new bool[10,10])
                {
                    DataContext = this
                };

                CurrentMap.Cow.Lives.Clear();
                for (int i = 0; i < Settings.CowLivesCount; i++)
                {
                    CurrentMap.Cow.Lives.Add(new LiveViewModel());
                }
            }
            else
            {
                CurrentPage = new SettingsPage()
                {
                    DataContext = this
                };
            }
        }

        private void OnLoadMapExecute()
        {
            var dialog = new OpenFileDialog()
            {
                Filter = "Text Files(*.txt)|*.txt"
            };
            if (dialog.ShowDialog() ?? false)
            {
                var file = new FileWorker(dialog.FileName);
                var text = file.Read();
                var map = TextToMapConverter.Convert(text);
                CurrentMap = new MapViewModel(map);
                BuildMap(map);
                ReloadObjects();
            }
        }

        private void BuildMap(IMap map)
        {
            switch (map.Size)
            {
                case 10:
                    CurrentPage = new Map10x10(CurrentMap.Bricks, map.Map);
                    break;
                case 8:
                    CurrentPage = new Map8x8();
                    break;
                case 6:
                    CurrentPage = new Map6x6();
                    break;
            }
        }

        private void ReloadObjects()
        {
            var map = CurrentMap.CurrentMap;
            CurrentMap = new MapViewModel(map);
            Settings = new SettingsViewModel()
            {
                BombSettings = CurrentMap.Bomb.Settings,
                WolfSettings = CurrentMap.Wolf.Settings,
                CannabisSettings = CurrentMap.Cannabis.Settings,
                CowSettings = CurrentMap.Cow.Settings
            };
            CurrentMap.OnGameResult += OnGameResult;
        }

        private void OnGameResult(object sender, bool isWin)
        {
            if (isWin)
            {
                MessageBox.Show("CONGRAT");
            }
            else
            {
                MessageBox.Show("FUC");
            }
            ReloadObjects();
        }

        public CowAndWeedGameViewModel()
        {
            MoveDownCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveDown());
            MoveUpCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveUp());
            MoveRightCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveRight());
            MoveLeftCommand = new RelayCommand(async () => await CurrentMap.Cow.MoveLeft());
            OpenSettingsCommand = new RelayCommand(OnOpenSettingsExecuted);
            OpenMapCommand = new RelayCommand(OnLoadMapExecute);
        }
    }
}
