using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using RSPO_UP_3.Services;
using RSPO_UP_3.View.Windows;

namespace RSPO_UP_3.Models
{
    public class QuizGame : ObservableObject
    {
        private readonly List<Question> _questions;
        public Question CurrentQuestion { get; private set; }
        public int CurrentPoints { get; private set; } = 0;

        public QuizGame()
        {
            _questions = QuestionDeserializer.GetQuestionsFromFile();
            foreach (var question in _questions)
                question.CurrentAnswers = new ObservableCollection<Answer>(question.Answers);

            CurrentQuestion = _questions[0] ?? throw new Exception("Вопросик был нуль");
        }

        public void NextQuestion()
        {
            int currentIndex = _questions.IndexOf(CurrentQuestion);
            if (IsLast())
            {
                OpenFinish();
                Application.Current.Shutdown();
            }
            else
                CurrentQuestion = _questions[currentIndex + 1];
        }

        public bool CheckForWinning(Answer first, Answer second)
        {
            if (first.IsRight && second.IsRight)
            {
                CurrentPoints++;
                return true;
            }

            return false;
        }

        private void OpenFinish()
        {
            FinishTestWindow w = new FinishTestWindow(CurrentPoints);
            w.ShowDialog();
        }

        public bool IsLast() => CurrentQuestion.Id == _questions.Max(x => x.Id);
    }
}
