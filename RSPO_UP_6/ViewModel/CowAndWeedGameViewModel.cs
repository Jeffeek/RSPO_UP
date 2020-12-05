using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_6.View;
using RSPO_UP_6.View.Maps;

namespace RSPO_UP_6.ViewModel
{
    public class CowAndWeedGameViewModel : ViewModelBase
    {
        private SettingsViewModel _settings;
        private CowViewModel _cow;
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

        private void OnOpenSettingsExecuted()
        {
            CurrentPage = new SettingsPage() {DataContext = this};
        }

        private bool CanOpenSettingsExecute() => !(CurrentPage is SettingsPage);

        public CowAndWeedGameViewModel()
        {
            _cow = new CowViewModel() {Size = 10};
            CurrentPage = new Map10x10();
            MoveDownCommand = new RelayCommand(async () => await _cow.MoveDown());
            MoveUpCommand = new RelayCommand( async () => await _cow.MoveUp());
            MoveRightCommand = new RelayCommand( async () => await _cow.MoveRight());
            MoveLeftCommand = new RelayCommand( async () => await _cow.MoveLeft());
            OpenSettingsCommand = new RelayCommand(OnOpenSettingsExecuted, CanOpenSettingsExecute);
        }
    }
}
