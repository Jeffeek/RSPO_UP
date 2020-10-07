using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using RSPO_UP_3.Services;
using RSPO_UP_3.View.Windows;

namespace RSPO_UP_3.Models.DataModels
{
    /// <summary>
    /// объект полноценной викторины, содержащей в себе вопросы
    /// </summary>
    public class QuizGame : ObservableObject
    {
        /// <summary>
        /// коллекция вопросов
        /// </summary>
        private readonly List<Question> _questions;
        /// <summary>
        /// объект вопроса, который на который в
        /// данный момент отвечает пользователь 
        /// </summary>
        public Question CurrentQuestion { get; private set; }
        /// <summary>
        /// количество баллов в данной игре
        /// </summary>
        public int CurrentPoints { get; private set; } = 0;

        /// <summary>
        /// конструктов по умолчанию для инициализации полей
        /// </summary>
        public QuizGame()
        {
            _questions = QuestionDeserializer.GetQuestionsFromFile();
            foreach (var question in _questions)
                question.CurrentAnswers = new ObservableCollection<Answer>(question.Answers);

            CurrentQuestion = _questions[0] ?? throw new Exception("Вопросик был нуль");
        }

        /// <summary>
        /// метод для рассчёта следующего вопроса \
        /// либо открытия финальной формы с результатом
        /// </summary>
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

        /// <summary>
        /// проверка двух ответов на корректность
        /// </summary>
        /// <param name="first">первый ответ</param>
        /// <param name="second">второй ответ</param>
        /// <returns>true - если оба верные,
        /// false - если хоть один из них неверный</returns>
        public bool CheckForWinning(Answer first, Answer second)
        {
            if (first.IsRight && second.IsRight)
            {
                CurrentPoints++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// метод для открытия финальной формы с результатом
        /// </summary>
        private void OpenFinish()
        {
            FinishTestWindow w = new FinishTestWindow(CurrentPoints);
            w.ShowDialog();
        }

        /// <summary>
        /// метод, проверяющий является ли текущий
        /// вопрос последним в данной игре
        /// </summary>
        /// <returns>true - если последний,
        /// false - если НЕ последний</returns>
        public bool IsLast() => CurrentQuestion.Id == _questions.Max(x => x.Id);
    }
}
