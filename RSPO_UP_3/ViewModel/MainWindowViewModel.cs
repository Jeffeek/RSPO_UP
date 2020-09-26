using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_3.Models;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private QuizGameViewModel _currentGame;

        public QuizGameViewModel CurrentGame
        {
            get => _currentGame;
            set => SetValue(ref _currentGame, value);
        }

        public MainWindowViewModel()
        {
            CurrentGame = new QuizGameViewModel(new QuizGame());
        }
    }
}
