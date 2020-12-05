using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_6.Model.Entities;
using RSPO_UP_6.View;
using RSPO_UP_6.View.Maps;

namespace RSPO_UP_6.ViewModel
{
    public class CowAndWeedGameViewModel : ViewModelBase
    {
        private SettingsViewModel _settings;
        private CowViewModel _cow;
        private WolfViewModel _wolf;
        private Page _currentPage;

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

        public SettingsViewModel Settings
        {
            get => _settings;
            set => SetValue(ref _settings, value);
        }

        private void OnOpenSettingsExecuted()
        {
            if (CurrentPage is SettingsPage)
            {
                CurrentPage = new Map10x10() {DataContext = this};
            }
            else
            {
                CurrentPage = new SettingsPage() {DataContext = Settings};
            }
        }

        public CowAndWeedGameViewModel()
        {
            Cow = new CowViewModel() {Size = 10};
            Wolf = new WolfViewModel() {Size = 10};
            Cow.CowPositionChanged += Wolf.CowMovedExecuted;
            Settings = new SettingsViewModel();
            CurrentPage = new Map10x10() {DataContext = this};
            MoveDownCommand = new RelayCommand(async () => await _cow.MoveDown());
            MoveUpCommand = new RelayCommand( async () => await _cow.MoveUp());
            MoveRightCommand = new RelayCommand( async () => await _cow.MoveRight());
            MoveLeftCommand = new RelayCommand( async () => await _cow.MoveLeft());
            OpenSettingsCommand = new RelayCommand(OnOpenSettingsExecuted);
        }
    }
}
