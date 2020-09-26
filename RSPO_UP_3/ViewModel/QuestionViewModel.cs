using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSPO_UP_3.Models;
using RSPO_UP_3.ViewModel.Base;

namespace RSPO_UP_3.ViewModel
{
    internal class QuestionViewModel : ViewModelBase
    {
        private Question _question;

        public Question Question
        {
            get => _question;
            set => SetValue(ref _question, value);
        }

        public QuestionViewModel(Question question)
        {
            Question = question;
        }
    }
}
