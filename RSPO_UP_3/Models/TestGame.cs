using System.Collections.Generic;
using System.Windows.Controls;
using RSPO_UP_3.Collections;

namespace RSPO_UP_3.Models
{
    public class TestGame
    {
        private List<Question> _questions;
        public Question CurrentQuestion { get; private set; }
        public int CurrentPoints { get; private set; } = 0;

        public TestGame()
        {
            _questions = QuestionGetter.GetQuestionsFromFile();
            CurrentQuestion = _questions[0];
        }

        public Question GetQuestionByIndex(int index)
        {
            return _questions[index];
        }

        public Question NextQuestion()
        {
            int currentIndex = _questions.IndexOf(CurrentQuestion);
            if (currentIndex == _questions.Count - 1)
                return null;
            CurrentQuestion = _questions[currentIndex + 1];
            return _questions[currentIndex + 1];
        }

        public void CheckForWin(CheckBox pressedCheckBox_1, CheckBox pressedCheckBox_2)
        {
            var currectAnswers = CurrentQuestion._rightAnswerVariants;
            AnswerVariant p1 = new AnswerVariant() { Text = pressedCheckBox_1.Content.ToString()};
            AnswerVariant p2 = new AnswerVariant() { Text = pressedCheckBox_2.Content.ToString() };
            if (currectAnswers[0].Equals(p1) || currectAnswers[0].Equals(p2))
            {
                if (currectAnswers[1].Equals(p1) || currectAnswers[1].Equals(p2))
                    CurrentPoints++;
            }
        }
    }
}
