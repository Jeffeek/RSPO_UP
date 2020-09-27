using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RSPO_UP_3.Models;
using ViewModelBase = RSPO_UP_3.ViewModel.Base.ViewModelBase;

namespace RSPO_UP_3.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private QuizGame _game;
        private bool _btn;
        private List<Answer> CheckedAnswers { get; }

        public bool IsEnabled
        { 
            get => _btn;
            set => SetValue(ref _btn, value, nameof(IsEnabled));
        }
        public QuizGame CurrentGame
        {
            get => _game;
            set => SetValue(ref _game, value);
        }

        public RelayCommand NextQuestionCommand =>
            new RelayCommand(() =>
            {
                CurrentGame.CheckForWinning(CheckedAnswers.First(), CheckedAnswers.Last());
                CheckedAnswers.Clear();
                CurrentGame.NextQuestion();
                OnPropertyChanged(nameof(CurrentGame));
                IsEnabled = false;
            });

        public RelayCommand<Answer> AnswerCheckCommand =>
            new RelayCommand<Answer>((obj) =>
        {
            if (CheckedAnswers.Exists(x => x.Text == obj.Text))
                CheckedAnswers.Remove(CheckedAnswers.Find(x => x.Text == obj.Text));
            else
                CheckedAnswers.Add(obj);
            IsEnabled = CheckedAnswers.Count == 2;
        });


        public MainWindowViewModel()
        {
            CurrentGame = new QuizGame();
            CheckedAnswers = new List<Answer>();
        }
    }
}
