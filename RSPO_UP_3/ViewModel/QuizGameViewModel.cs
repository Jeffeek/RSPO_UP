using RSPO_UP_3.Models;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    internal class QuizGameViewModel : ViewModelBase
    {
        private QuizGame _game;
        public QuizGame Game
        {
            get => _game;
            set => SetValue(ref _game, value);
        }

        public QuizGameViewModel(QuizGame game)
        {
            _game = game;
        }

        public QuizGameViewModel()
        {
            
        }
    }
}
