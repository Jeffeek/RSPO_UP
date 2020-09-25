using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_3.Collections;

namespace RSPO_UP_3.Models
{
    public class TestGame
    {
        private List<Question> questions;

        public TestGame()
        {
            questions = QuestionGetter.GetQuestionsFromFile();
        }

        public 
    }
}
