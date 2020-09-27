using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using RSPO_UP_3.Models;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private QuizGame _game;
        private ObservableCollection<CheckBox> choosedCheckBoxes = new ObservableCollection<CheckBox>();
        private RelayCommand _moveNextCommand;
        private RelayCommand<CheckBox> _checkBoxCommandCommand;

        public bool IsButtonEnabled => choosedCheckBoxes.Count == 2;

        public RelayCommand NextCommand => new RelayCommand((() =>
        {
            _game.NextQuestion();
            OnPropertyChanged(nameof(CurrentGame));
        }), () => _game.IsLast());

        public RelayCommand<CheckBox> CheckBoxCommand =>
            new RelayCommand<CheckBox>(TB, (x) => choosedCheckBoxes.Count < 2);

        private void TB(object tb)
        {
            var checkBox = tb as CheckBox;
            if (choosedCheckBoxes.Contains(checkBox))
                choosedCheckBoxes.Remove(checkBox);
            else
                choosedCheckBoxes.Add(checkBox);
        }

        public QuizGame CurrentGame
        {
            get => _game;
            set => SetValue(ref _game, value);
        }

        public MainWindowViewModel()
        {
            CurrentGame = new QuizGame();
        }
    }
}
