using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using RSPO_UP_3.Models;
using RSPO_UP_3.Models.DataModels;
using ViewModelBase = RSPO_UP_3.ViewModel.Base.ViewModelBase;

namespace RSPO_UP_3.ViewModel
{
    internal class StudentWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// объект текущей игры
        /// </summary>
        private QuizGame _game;
        /// <summary>
        /// булево значение, показывающее доступа ли кнопка для нажатия
        /// </summary>
        private bool _isButtonEnabled;
        /// <summary>
        /// коллекция текущих выбранных ответов
        /// </summary>
        private List<Answer> CheckedAnswers { get; }
        /// <summary>
        /// команда, для передвижения по вопросам в текущей игре
        /// </summary>
        public ICommand NextQuestionCommand { get; }
        /// <summary>
        /// команда, для проверки нажатого чекбокса
        /// </summary>
        public ICommand CheckBoxCommand { get; }

        public bool IsButtonEnabled
        { 
            get => _isButtonEnabled;
            set => SetValue(ref _isButtonEnabled, value, nameof(IsButtonEnabled));
        }
        public QuizGame CurrentGame
        {
            get => _game;
            set => SetValue(ref _game, value);
        }

        /// <summary>
        /// метод для передвижения по текущему вопросу
        /// </summary>
        private void OnNextQuestionCommand()
        {
            CurrentGame.CheckForWinning(CheckedAnswers.First(), CheckedAnswers.Last());
            CheckedAnswers.Clear();
            CurrentGame.NextQuestion();
            OnPropertyChanged(nameof(CurrentGame));
            IsButtonEnabled = false;
        }

        /// <summary>
        /// метод для нажатого чекбокса
        /// </summary>
        /// <param name="obj">нажатый чекбокс с ответом</param>
        private void OnCheckBoxCheckedCommand(Answer obj)
        {
            if (CheckedAnswers.Exists(x => x.Text == obj.Text))
                CheckedAnswers.Remove(CheckedAnswers.Find(x => x.Text == obj.Text));
            else
                CheckedAnswers.Add(obj);
            IsButtonEnabled = CheckedAnswers.Count == 2;
        }

        /// <summary>
        /// конструктор по умолчанию для инициализации
        /// </summary>
        public StudentWindowViewModel()
        {
            CurrentGame = new QuizGame();
            CheckedAnswers = new List<Answer>();
            NextQuestionCommand = new RelayCommand(OnNextQuestionCommand);
            CheckBoxCommand = new RelayCommand<Answer>(OnCheckBoxCheckedCommand);
        }
    }
}
