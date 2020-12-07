using System;
using System.Collections.ObjectModel;
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
        private CowViewModel _cow;
        private WolfViewModel _wolf;
        private BombViewModel _bomb;
        private CannabisViewModel _cannabis;
        private Page _currentPage;
        private IMap _currentMap;
        private ObservableCollection<BrickViewModel> _bricks;

        public ICommand OpenSettingsCommand { get; }
        public ICommand OpenMapCommand { get; }

        public ICommand MoveUpCommand { get; }
        public ICommand MoveDownCommand { get; }
        public ICommand MoveLeftCommand { get; }
        public ICommand MoveRightCommand { get; }

        public ObservableCollection<BrickViewModel> Bricks
        {
            get => _bricks;
            set => SetValue(ref _bricks, value);
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
                CurrentPage = new Map10x10(Bricks, new bool[10,10])
                {
                    DataContext = this
                };

                Cow.Lives.Clear();
                for (int i = 0; i < Settings.CowLivesCount; i++)
                {
                    Cow.Lives.Add(new LiveViewModel());
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
                _currentMap = map;
                BuildMap(map);
                ReloadObjects();
            }
        }

        private void BuildMap(IMap map)
        {
            switch (map.Size)
            {
                case 10:
                    CurrentPage = new Map10x10(Bricks, map.Map);
                    break;
                case 8:
                    CurrentPage = new Map8x8();
                    break;
                case 6:
                    CurrentPage = new Map6x6();
                    break;
                default:
                {
                    throw new Exception();
                }
            }
        }

        private void ReloadObjects()
        {
            Cow = new CowViewModel()
            {
                Size = _currentMap.Size, 
                Bricks = Bricks, 
                Row = 0, Column = 0
            };
            Wolf = new WolfViewModel()
            {
                Size = _currentMap.Size,
                Row = 0, Column = _currentMap.Size - 1, 
                Bricks = Bricks
            };
            Bomb = new BombViewModel()
            {
                Size = _currentMap.Size
            };
            Cannabis = new CannabisViewModel()
            {
                Size = _currentMap.Size
            };
            Cow.CowPositionChanged += Wolf.CowMovedExecuted;
            Settings = new SettingsViewModel()
            {
                BombSettings = Bomb.Settings,
                CannabisSettings = Cannabis.Settings,
                WolfSettings = Wolf.Settings,
                CowSettings = Cow.Settings
            };
        }

        public CowAndWeedGameViewModel()
        {
            Bricks = new ObservableCollection<BrickViewModel>();
            _currentMap = new Map10X10(new bool[10,10]);
            ReloadObjects();
            MoveDownCommand = new RelayCommand(async () => await _cow.MoveDown());
            MoveUpCommand = new RelayCommand( async () => await _cow.MoveUp());
            MoveRightCommand = new RelayCommand( async () => await _cow.MoveRight());
            MoveLeftCommand = new RelayCommand( async () => await _cow.MoveLeft());
            OpenSettingsCommand = new RelayCommand(OnOpenSettingsExecuted);
            OpenMapCommand = new RelayCommand(OnLoadMapExecute);
            CurrentPage = new Map10x10(Bricks, new bool[10,10])
            {
                DataContext = this
            };
        }
    }
}
