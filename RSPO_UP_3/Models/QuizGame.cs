using System;
using System.Collections.Generic;
using RSPO_UP_3.Services;

namespace RSPO_UP_3.Models
{
    public class QuizGame
    {
        private List<Question> _questions;
        public Question CurrentQuestion { get; private set; }
        public int CurrentPoints { get; private set; } = 0;

        public QuizGame()
        {
            _questions = QuestionDeserializer.GetQuestionsFromFile();
            CurrentQuestion = _questions[0] ?? throw new Exception("Вопросик был нуль");
        }

        public Question GetQuestionByIndex(int index)
        {
            if (index < 0 || index >= _questions.Count) 
                throw new IndexOutOfRangeException(nameof(_questions));
            return _questions[index];
        }

        public bool NextQuestion()
        {
            int currentIndex = _questions.IndexOf(CurrentQuestion);
            if (currentIndex == _questions.Count - 1)
                return false;
            CurrentQuestion = _questions[currentIndex + 1];
            return true;
        }

        public bool CheckForWinning(Answer answer1, Answer answer2)
        {
            if (answer1.IsRight && answer2.IsRight)
            {
                CurrentPoints++;
                return true;
            }

            return false;
        }
    }
}
