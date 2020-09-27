using System;
using System.Collections.Generic;
using System.Linq;
using RSPO_UP_3.Services;
using RSPO_UP_3.View.Windows;

namespace RSPO_UP_3.Models
{
    public class QuizGame
    {
        private readonly List<Question> _questions;
        public Question CurrentQuestion { get; private set; }
        public int CurrentPoints { get; private set; } = 0;

        public QuizGame()
        {
            _questions = QuestionDeserializer.GetQuestionsFromFile();
            CurrentQuestion = _questions[0] ?? throw new Exception("Вопросик был нуль");
        }

        public void NextQuestion()
        {
            int currentIndex = _questions.IndexOf(CurrentQuestion);
            if (IsLast())
                OpenFinish();
            else
                CurrentQuestion = _questions[currentIndex + 1];
        }

        public bool CheckForWinning(string first, string second)
        {
            var right = CurrentQuestion.RightAnswers;
            if (right[0].Text == first || right[0].Text == second)
            {
                if (right[1].Text == first || right[1].Text == second)
                {
                    CurrentPoints++;
                    return true;
                }
            }

            return false;
        }

        private void OpenFinish()
        {
            FinishTestWindow w = new FinishTestWindow(this);
            w.ShowDialog();
        }

        public bool IsLast() => CurrentQuestion.Id == _questions.Max(x => x.Id);
    }
}
