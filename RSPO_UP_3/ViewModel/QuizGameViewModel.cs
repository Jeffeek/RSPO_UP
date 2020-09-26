using RSPO_UP_3.Models;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    internal class QuizGameViewModel : ViewModelBase
    {
        private QuizGame _game;
        private RelayCommand _next;
        public RelayCommand Next => _next ?? new RelayCommand(x =>
        {
            Game.NextQuestion(); 
            OnPropertyChanged(nameof(Game));
        });

        public QuizGame Game
        {
            get => _game;
            set => SetValue(ref _game, value);
        }

        public QuizGameViewModel(QuizGame game)
        {
            _game = game;
        }

        public QuizGameViewModel() { }
    }
}
